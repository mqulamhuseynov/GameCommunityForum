using GamingForumDomain.Entities.ForumEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingForumInfrastructure.Configurations
{
    public class TopicTagConfiguration : IEntityTypeConfiguration<TopicTag>
    {
        public void Configure(EntityTypeBuilder<TopicTag> builder)
        {
            builder.ToTable("TopicTags");

            // Composite PK: eyni topic-e eyni tag iki defe elave oluna bilmez
            builder.HasKey(tt => new { tt.TopicId, tt.TagId });

            builder.HasOne(tt => tt.Topic)
                   .WithMany(t => t.Tags)
                   .HasForeignKey(tt => tt.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tt => tt.Tag)
                   .WithMany(t => t.Topics)
                   .HasForeignKey(tt => tt.TagId)
                   .OnDelete(DeleteBehavior.Cascade);

            // "Bu tag-li butun topic-ler" query-si ucun
            builder.HasIndex(tt => tt.TagId);

            // Topic/Tag-in query filter-i var, bunun yoxdur -> EF warning verir.
            // Bu setir hem warning-i susdurur, hem de silinmis topic-in
            // tag-larinin siyahilarda gorunmesinin qarsisini alir.
            builder.HasQueryFilter(tt => !tt.Topic.IsDeleted && !tt.Tag.IsDeleted);
        }
    }
}
