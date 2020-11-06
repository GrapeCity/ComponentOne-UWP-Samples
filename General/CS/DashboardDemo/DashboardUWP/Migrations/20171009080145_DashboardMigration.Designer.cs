using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DashboardModel;

namespace DashboardUWP.Migrations
{
    [DbContext(typeof(DashboardContext))]
    [Migration("20171009080145_DashboardMigration")]
    partial class DashboardMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("DashboardModel.BudgetItem", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Expences");

                    b.Property<double>("Goal");

                    b.Property<double>("Profit");

                    b.Property<double>("Sales");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("DashboardModel.Campaign", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("Finish");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("DashboardModel.Category", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DashboardModel.Customer", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.Property<int>("RegionId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DashboardModel.LeadHistoryItem", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Comment");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("LeadStateId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LeadStateId");

                    b.ToTable("LeadHistory");
                });

            modelBuilder.Entity("DashboardModel.LeadState", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LeadStates");
                });

            modelBuilder.Entity("DashboardModel.OpportunityItem", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Customer");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Level");

                    b.Property<int>("LevelId");

                    b.Property<double>("Sales");

                    b.HasKey("Id");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("DashboardModel.Product", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CategoryId");

                    b.Property<double>("Cost");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DashboardModel.ProfitAndSale", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Campaign");

                    b.Property<string>("Category");

                    b.Property<string>("Customer");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Product");

                    b.Property<double>("Profit");

                    b.Property<double>("Quantity");

                    b.Property<string>("Region");

                    b.Property<double>("Sales");

                    b.HasKey("Id");

                    b.ToTable("ProfitAndSales");
                });

            modelBuilder.Entity("DashboardModel.Region", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.Property<double>("X");

                    b.Property<double>("Y");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("DashboardModel.RegionSalesGoal", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Goal");

                    b.Property<double>("Profit");

                    b.Property<int>("RegionId");

                    b.Property<double>("Sales");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("RegionSales");
                });

            modelBuilder.Entity("DashboardModel.RegionWiseSale", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Customer");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Product");

                    b.Property<double>("Profit");

                    b.Property<string>("Region");

                    b.Property<int>("RegionId");

                    b.Property<double>("Sales");

                    b.Property<double>("X");

                    b.Property<double>("Y");

                    b.HasKey("Id");

                    b.ToTable("RegionWiseSales");
                });

            modelBuilder.Entity("DashboardModel.Sale", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CampaignId");

                    b.Property<double>("Cost");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ProductId");

                    b.Property<double>("Quantity");

                    b.Property<double>("Summ");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("DashboardModel.Shop", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.Property<int>("RegionId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("DashboardModel.BudgetItem", b =>
                {
                    b.HasOne("DashboardModel.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DashboardModel.Customer", b =>
                {
                    b.HasOne("DashboardModel.Region", "Region")
                        .WithMany("Customers")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DashboardModel.LeadHistoryItem", b =>
                {
                    b.HasOne("DashboardModel.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DashboardModel.LeadState", "LeadState")
                        .WithMany()
                        .HasForeignKey("LeadStateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DashboardModel.Product", b =>
                {
                    b.HasOne("DashboardModel.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DashboardModel.RegionSalesGoal", b =>
                {
                    b.HasOne("DashboardModel.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DashboardModel.Sale", b =>
                {
                    b.HasOne("DashboardModel.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DashboardModel.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DashboardModel.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DashboardModel.Shop", b =>
                {
                    b.HasOne("DashboardModel.Region", "Region")
                        .WithMany("Shops")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
