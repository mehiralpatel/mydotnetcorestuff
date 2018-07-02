using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data
{
    public partial class PPMContext : DbContext
    {
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomTask> CustomTask { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentCategory> DocumentCategory { get; set; }
        public virtual DbSet<DocumentParent> DocumentParent { get; set; }
        public virtual DbSet<DocumentVersion> DocumentVersion { get; set; }
        public virtual DbSet<GlobalSettings> GlobalSettings { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectResourceAssignment> ProjectResourceAssignment { get; set; }
        public virtual DbSet<ProjectSkillSet> ProjectSkillSet { get; set; }
        public virtual DbSet<Proposal> Proposal { get; set; }
        public virtual DbSet<ProposalPayment> ProposalPayment { get; set; }
        public virtual DbSet<ProposalResourceType> ProposalResourceType { get; set; }
        public virtual DbSet<ProposalTechnologyMap> ProposalTechnologyMap { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceTechnologyMap> ResourceTechnologyMap { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Sprint> Sprint { get; set; }
        public virtual DbSet<Technology> Technology { get; set; }
        public virtual DbSet<TechnologySkill> TechnologySkill { get; set; }
        public virtual DbSet<TimeSheet> TimeSheet { get; set; }
        public virtual DbSet<UserSkillTags> UserSkillTags { get; set; }
        public virtual DbSet<WorkItem> WorkItem { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=192.168.10.11;Database=PPM;user id=ppm;password=Password#456@;");
        //            }
        //        }

        public PPMContext(DbContextOptions<PPMContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Currency)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Currency_Country");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Customer_Country");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirebaseInfo).HasMaxLength(250);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastDateModified).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CustomTask>(entity =>
            {
                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomTaskName).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.CustomTaskCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomTask_Resource");

                entity.HasOne(d => d.LastModifiedByUser)
                    .WithMany(p => p.CustomTaskLastModifiedByUser)
                    .HasForeignKey(d => d.LastModifiedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomTask_Resource1");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.CustomTaskResource)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_CustomTask_Resource2");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedByDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.DocumentCategory)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocumentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_DocumentCategory");
            });

            modelBuilder.Entity<DocumentCategory>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.DocumentParent)
                    .WithMany(p => p.DocumentCategory)
                    .HasForeignKey(d => d.DocumentParentId)
                    .HasConstraintName("FK_DocumentCategory_DocumentParent");
            });

            modelBuilder.Entity<DocumentParent>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<DocumentVersion>(entity =>
            {
                entity.Property(e => e.ContentType).HasMaxLength(200);

                entity.Property(e => e.CoverImageFilePath).HasMaxLength(500);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).HasMaxLength(15);

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.LastModifiedByDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StoragePath).HasMaxLength(500);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentVersion)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentVersion_Document");
            });

            modelBuilder.Entity<GlobalSettings>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ProjectCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Resource");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Project_Customer");

                entity.HasOne(d => d.LastModifiedByUser)
                    .WithMany(p => p.ProjectLastModifiedByUser)
                    .HasForeignKey(d => d.LastModifiedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Resource1");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Project_Model");

                entity.HasOne(d => d.Proposal)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ProposalId)
                    .HasConstraintName("FK_Project_Proposal");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("FK_Project_Technology");
            });

            modelBuilder.Entity<ProjectResourceAssignment>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectResourceAssignment)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectResourceAssignment_Project");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ProjectResourceAssignment)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_ProjectResourceAssignment_Resource");
            });

            modelBuilder.Entity<ProjectSkillSet>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectSkillSet)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectSkillSet_Project");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.ProjectSkillSet)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_ProjectSkillSet_Skill");
            });

            modelBuilder.Entity<Proposal>(entity =>
            {
                entity.Property(e => e.ProposalId).HasColumnName("ProposalID");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ProposalAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProposalDate).HasColumnType("date");

                entity.Property(e => e.ProposalRef)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SignoffAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SignoffDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Proposal)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proposal_Currency");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Proposal)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proposal_Customer");
            });

            modelBuilder.Entity<ProposalPayment>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.PlannedInvoiceAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PlannedInvoiceDate).HasColumnType("date");

                entity.Property(e => e.PlannedRemittanceDate).HasColumnType("date");

                entity.HasOne(d => d.Proposal)
                    .WithMany(p => p.ProposalPayment)
                    .HasForeignKey(d => d.ProposalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProposalPayment_Proposal");
            });

            modelBuilder.Entity<ProposalResourceType>(entity =>
            {
                entity.Property(e => e.ApprovedHours).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.Rates).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Proposal)
                    .WithMany(p => p.ProposalResourceType)
                    .HasForeignKey(d => d.ProposalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProposalResourceType_Proposal");

                entity.HasOne(d => d.ResourceType)
                    .WithMany(p => p.ProposalResourceType)
                    .HasForeignKey(d => d.ResourceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProposalResourceType_ResourceType");
            });

            modelBuilder.Entity<ProposalTechnologyMap>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Proposal)
                    .WithMany(p => p.ProposalTechnologyMap)
                    .HasForeignKey(d => d.ProposalId)
                    .HasConstraintName("FK_ProposalTechnologyMap_ProposalTechnologyMap");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.ProposalTechnologyMap)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("FK_ProposalTechnologyMap_Technology");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Cvurl)
                    .HasColumnName("CVURL")
                    .HasMaxLength(500);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.Exp).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.JobTitle).HasMaxLength(200);

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ProfileUrl)
                    .HasColumnName("ProfileURL")
                    .HasMaxLength(500);

                entity.Property(e => e.ReleventExp).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RelievingDate).HasColumnType("datetime");

                entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

                entity.Property(e => e.Telephonenumber).HasMaxLength(20);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Resource_Branch");

                entity.HasOne(d => d.ResourceType)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.ResourceTypeId)
                    .HasConstraintName("FK_Resource_ResourceType");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Resource_Role");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("FK_Resource_Technology");
            });

            modelBuilder.Entity<ResourceTechnologyMap>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceTechnologyMap)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_ResourceTechnologyMap_Resource");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.ResourceTechnologyMap)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("FK_ResourceTechnologyMap_ResourceTechnologyMap");
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.LastModifiedByDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Sprint>(entity =>
            {
                entity.Property(e => e.SprintId).HasColumnName("SprintID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Velocity).HasColumnType("char(10)");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Sprint)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Sprint_Project");
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TechnologySkill>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TechnologySkill)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_TechnologySkill_Skill");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.TechnologySkill)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("FK_TechnologySkill_Technology");
            });

            modelBuilder.Entity<TimeSheet>(entity =>
            {
                entity.Property(e => e.BillableTimeSpentByBd).HasColumnName("BillableTimeSpentByBD");

                entity.Property(e => e.BillableTimeSpentByPm).HasColumnName("BillableTimeSpentByPM");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomTaskId).HasColumnName("CustomTaskID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.LastModifiedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ParentWorkItemId).HasColumnName("ParentWorkItemID");

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.TimeSheetAppovedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.TimeSheetCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSheet_Resource");

                entity.HasOne(d => d.CustomTask)
                    .WithMany(p => p.TimeSheet)
                    .HasForeignKey(d => d.CustomTaskId)
                    .HasConstraintName("FK_TimeSheet_CustomTask");

                entity.HasOne(d => d.LastModifiedByUser)
                    .WithMany(p => p.TimeSheetLastModifiedByUser)
                    .HasForeignKey(d => d.LastModifiedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSheet_Resource1");

                entity.HasOne(d => d.ParentWorkItem)
                    .WithMany(p => p.TimeSheet)
                    .HasForeignKey(d => d.ParentWorkItemId)
                    .HasConstraintName("FK_TimeSheet_WorkItem");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.TimeSheetResource)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSheet_Resource2");

                entity.HasOne(d => d.TimeSheetApprovalByUser)
                    .WithMany(p => p.TimeSheetTimeSheetApprovalByUser)
                    .HasForeignKey(d => d.TimeSheetApprovalByUserId)
                    .HasConstraintName("FK_TimeSheet_Resource3");
            });

            modelBuilder.Entity<UserSkillTags>(entity =>
            {
                entity.HasKey(e => e.SkillUserId);

                entity.Property(e => e.SkillUserId).HasColumnName("SkillUserID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.SkillId).HasColumnName("SkillID");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.UserSkillTags)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_UserSkillTags_Resource");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkillTags)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_UserSkillTags_Skill");
            });

            modelBuilder.Entity<WorkItem>(entity =>
            {
                entity.HasKey(e => e.ParentWorkItemId);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SprintId).HasColumnName("SprintID");
            });
        }
    }
}
