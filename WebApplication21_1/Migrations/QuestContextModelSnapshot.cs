// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication21_1.Data;

#nullable disable

namespace WebApplication21_1.Migrations
{
    [DbContext(typeof(QuestContext))]
    partial class QuestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication21_1.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int>("LevelFear")
                        .HasColumnType("int");

                    b.Property<int>("PlayersCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Quests");
                });
#pragma warning restore 612, 618
        }
    }
}
