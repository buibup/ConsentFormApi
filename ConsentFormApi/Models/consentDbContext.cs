using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsentFormApi.Models
{
    public partial class consentDbContext : DbContext
    {
        public virtual DbSet<ApplicationConfigurations> ApplicationConfigurations { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomersAgrees> CustomersAgrees { get; set; }
        public virtual DbSet<CustomersSurveysData> CustomersSurveysData { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SubTopic> SubTopics { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<TemplateDetails> TemplateDetails { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.users_roles'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.categories_permissions'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=10.90.10.36;Database=consentDb;User Id=sa;Password='bW(|)B$q|1';");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationConfigurations>(entity =>
            {
                entity.ToTable("application_configurations");

                entity.HasIndex(e => e.Id)
                    .HasName("application_configurations_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .IsRowVersion();

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.ToTable("attachments");

                entity.HasIndex(e => e.Id)
                    .HasName("attachments_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ExpiryAt)
                    .HasColumnName("expiry_at")
                    .HasColumnType("date");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.Id)
                    .HasName("categories_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.Id)
                    .HasName("customers_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressNo)
                    .HasColumnName("address_no")
                    .HasMaxLength(300);

                entity.Property(e => e.AgeDay).HasColumnName("age_day");

                entity.Property(e => e.AgeMonth).HasColumnName("age_month");

                entity.Property(e => e.AgeYear).HasColumnName("age_year");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstnameEn)
                    .HasColumnName("firstname_en")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstnameTh)
                    .HasColumnName("firstname_th")
                    .HasMaxLength(255);

                entity.Property(e => e.Hn)
                    .IsRequired()
                    .HasColumnName("hn")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .HasColumnName("home_phone")
                    .HasMaxLength(300);

                entity.Property(e => e.IdCard)
                    .HasColumnName("id_card")
                    .HasMaxLength(20);

                entity.Property(e => e.LanguageCode)
                    .HasColumnName("language_code")
                    .HasMaxLength(3);

                entity.Property(e => e.LastnameEn)
                    .HasColumnName("lastname_en")
                    .HasMaxLength(255);

                entity.Property(e => e.LastnameTh)
                    .HasColumnName("lastname_th")
                    .HasMaxLength(255);

                entity.Property(e => e.Membership).HasColumnName("membership");

                entity.Property(e => e.MembershipAt)
                    .HasColumnName("membership_at")
                    .HasColumnType("date");

                entity.Property(e => e.MiddlenameEn)
                    .HasColumnName("middlename_en")
                    .HasMaxLength(255);

                entity.Property(e => e.MiddlenameTh)
                    .HasColumnName("middlename_th")
                    .HasMaxLength(255);

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobile_phone")
                    .HasMaxLength(300);

                entity.Property(e => e.Nationality)
                    .HasColumnName("nationality")
                    .HasMaxLength(100);

                entity.Property(e => e.OfficePhone)
                    .HasColumnName("office_phone")
                    .HasMaxLength(300);

                entity.Property(e => e.PapmiRowId).HasColumnName("papmi_row_id");

                entity.Property(e => e.PassportNumber)
                    .HasColumnName("passport_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("ntext");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasMaxLength(200);

                entity.Property(e => e.SecretaryNumber)
                    .HasColumnName("secretary_number")
                    .HasColumnType("ntext");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(20);

                entity.Property(e => e.TitleEn)
                    .HasColumnName("title_en")
                    .HasMaxLength(20);

                entity.Property(e => e.TitleTh)
                    .HasColumnName("title_th")
                    .HasMaxLength(20);

                entity.Property(e => e.Vip).HasColumnName("vip");

                entity.Property(e => e.VipDesc)
                    .HasColumnName("vip_desc")
                    .HasMaxLength(200);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<CustomersAgrees>(entity =>
            {
                entity.ToTable("customers_agrees");

                entity.HasIndex(e => e.Id)
                    .HasName("customers_agrees_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Paper)
                    .HasColumnName("paper")
                    .HasColumnType("ntext");

                entity.Property(e => e.SignedAt)
                    .HasColumnName("signed_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TemplateId).HasColumnName("template_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersAgrees)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("customers_agrees_customers_id_fk");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.CustomersAgrees)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("customers_agrees_templates_id_fk");
            });

            modelBuilder.Entity<CustomersSurveysData>(entity =>
            {
                entity.ToTable("customers_surveys_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(format(getdate(),'yyyy-MM-dd HH:mm'))");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.SubTopicId).HasColumnName("sub_topic_id");

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.ToTable("languages");

                entity.HasIndex(e => e.Id)
                    .HasName("languages_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasColumnName("alias")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Alias)
                    .HasName("roles_alias_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("roles_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SubTopic>(entity =>
            {
                entity.ToTable("sub_topics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.TopicId).HasColumnName("topic_Id");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.SubTopics)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sub_topic_fk0");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("surveys");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<TemplateDetails>(entity =>
            {
                entity.ToTable("template_details");

                entity.HasIndex(e => e.Id)
                    .HasName("template_details_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("ntext");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.TemplateId).HasColumnName("template_id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Templates>(entity =>
            {
                entity.ToTable("templates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Templates)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("templates_categories_id_fk");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("topics_fk0");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id)
                    .HasName("users_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(300);

                entity.Property(e => e.SsusrInitials)
                    .HasColumnName("ssusr_initials")
                    .HasMaxLength(20);
            });
        }
    }
}
