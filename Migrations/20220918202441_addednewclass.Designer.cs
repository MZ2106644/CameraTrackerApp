// <auto-generated />
using CameraTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CameraTrackerApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220918202441_addednewclass")]
    partial class addednewclass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CameraTrackerApp.Models.Camera", b =>
                {
                    b.Property<int>("CameraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CameraID"), 1L, 1);

                    b.Property<string>("CameraName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CameraType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HangingLocation")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<bool>("PrivateAimed")
                        .HasColumnType("bit");

                    b.Property<bool>("PublicAimed")
                        .HasColumnType("bit");

                    b.HasKey("CameraID");

                    b.ToTable("Camera");
                });
#pragma warning restore 612, 618
        }
    }
}
