using ConversationService.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversationService.Entity.Configuration
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder
                .ToTable("ConversationDetails")
                .HasKey("Id");

            builder
                .Property(e => e.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.
                 Property(x => x.StartMeetingDate)
                .HasColumnType("datetime2")
                .HasMaxLength(20)
                .IsRequired();

            builder.
                 Property(x => x.EndMeetingDate)
                .HasColumnType("datetime2")
                .HasMaxLength(20);

            builder
                .Property(x => x.ClientId)
                .IsRequired();

            builder.Property(x => x.Messages);

            builder
                .Property(x => x.MeetingTopic)
                .IsRequired();

            builder
                .Property(x => x.ConversationStatus)
                .IsRequired();

            builder
                .Property(x => x.ClosedBy)
                .IsRequired();

            builder
                .Property(x => x.MeetingId)
                .IsRequired();
        }
    }
}