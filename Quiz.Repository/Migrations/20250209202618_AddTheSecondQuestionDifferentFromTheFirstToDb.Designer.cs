﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz.Repository.Data;

#nullable disable

namespace Quiz.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250209202618_AddTheSecondQuestionDifferentFromTheFirstToDb")]
    partial class AddTheSecondQuestionDifferentFromTheFirstToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionId = 1,
                            Text = "Јакупица",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 2,
                            QuestionId = 1,
                            Text = "Шар Планина",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 3,
                            QuestionId = 1,
                            Text = "Кораб",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 4,
                            QuestionId = 1,
                            Text = "Пелистер",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 5,
                            QuestionId = 2,
                            Text = "Треска",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 6,
                            QuestionId = 2,
                            Text = "Црна Река",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 7,
                            QuestionId = 2,
                            Text = "Брегалница",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 8,
                            QuestionId = 2,
                            Text = "Вардар",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 9,
                            QuestionId = 3,
                            Text = "Преспа",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 10,
                            QuestionId = 3,
                            Text = "Дојран",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 11,
                            QuestionId = 3,
                            Text = "Охрид",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 12,
                            QuestionId = 3,
                            Text = "Тиквеш",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 13,
                            QuestionId = 4,
                            Text = "Галичица",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 14,
                            QuestionId = 4,
                            Text = "Маврово",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 15,
                            QuestionId = 4,
                            Text = "Јасен",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 16,
                            QuestionId = 4,
                            Text = "Пелистер",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 17,
                            QuestionId = 5,
                            Text = "Битола",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 18,
                            QuestionId = 5,
                            Text = "Охрид",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 19,
                            QuestionId = 5,
                            Text = "Куманово",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 20,
                            QuestionId = 5,
                            Text = "Тетово",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 21,
                            QuestionId = 6,
                            Text = "Дарданиа",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 22,
                            QuestionId = 6,
                            Text = "Пеониа",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 23,
                            QuestionId = 6,
                            Text = "Алирија",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 24,
                            QuestionId = 6,
                            Text = "Англија",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 25,
                            QuestionId = 7,
                            Text = "1989",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 26,
                            QuestionId = 7,
                            Text = "1995",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 27,
                            QuestionId = 7,
                            Text = "1991",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 28,
                            QuestionId = 7,
                            Text = "2001",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 29,
                            QuestionId = 8,
                            Text = "Филип II Македонски",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 30,
                            QuestionId = 8,
                            Text = "Александар Македонски",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 31,
                            QuestionId = 8,
                            Text = "Јустинијан I",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 32,
                            QuestionId = 8,
                            Text = "Скендербег",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 33,
                            QuestionId = 9,
                            Text = "Римската империја",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 34,
                            QuestionId = 9,
                            Text = "Византиска империја",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 35,
                            QuestionId = 9,
                            Text = "Отоманската империја",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 36,
                            QuestionId = 9,
                            Text = "Австро - унгарската империја",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 37,
                            QuestionId = 10,
                            Text = "Скопски договор",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 38,
                            QuestionId = 10,
                            Text = "Договорот од Преспа",
                            isCorrect = true
                        },
                        new
                        {
                            Id = 39,
                            QuestionId = 10,
                            Text = "Балкански договор",
                            isCorrect = false
                        },
                        new
                        {
                            Id = 40,
                            QuestionId = 10,
                            Text = "Охридски рамковен договор",
                            isCorrect = false
                        });
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Провери си го знаење за Географија во Северна Македонија",
                            EndDate = new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Географија на Северна Македонија",
                            StartDate = new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Провери си го знаење за Историја во Северна Македонија",
                            EndDate = new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Историја на Северна Македонија",
                            StartDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Event_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Events_Users");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuizId = 1,
                            Text = "Која е највисоката планина во Северна Македонија?"
                        },
                        new
                        {
                            Id = 2,
                            QuizId = 1,
                            Text = "Која е најголема река во Северна Македонија?"
                        },
                        new
                        {
                            Id = 3,
                            QuizId = 1,
                            Text = "Кое е најголемото природно езеро во Северна Македонија?"
                        },
                        new
                        {
                            Id = 4,
                            QuizId = 1,
                            Text = "Кој национален парк е дом на загрозениот балкански рис?"
                        },
                        new
                        {
                            Id = 5,
                            QuizId = 1,
                            Text = "Кој од наведените градови е втор по големина во Северна Македонија?"
                        },
                        new
                        {
                            Id = 6,
                            QuizId = 2,
                            Text = "Кое античко кралство ја опфаќало територијата на модерна Северна Македонија?"
                        },
                        new
                        {
                            Id = 7,
                            QuizId = 2,
                            Text = "Која година Северна Македонија прогласи независност од Југославија?"
                        },
                        new
                        {
                            Id = 8,
                            QuizId = 2,
                            Text = "Која позната историска личност, родена во Пела, Грција, имаше значително влијание врз регионот на Северна Македонија?"
                        },
                        new
                        {
                            Id = 9,
                            QuizId = 2,
                            Text = "Која империја владеела со територијата на модерна Северна Македонија над 500 години?"
                        },
                        new
                        {
                            Id = 10,
                            QuizId = 2,
                            Text = "Како се викаше договорот со кој се реши долгогодишниот спор за името меѓу Грција и Северна Македонија во 2018 година?"
                        });
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeQuizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.HasIndex("TypeQuizeId")
                        .IsUnique();

                    b.ToTable("Quizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventId = 1,
                            Name = "Брза Географија",
                            TypeQuizeId = 1
                        },
                        new
                        {
                            Id = 2,
                            EventId = 2,
                            Name = "Пат низ минатотo",
                            TypeQuizeId = 2
                        });
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.TypeQuiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeQuizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Географија"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Историја"
                        });
                });

            modelBuilder.Entity("Quiz.Domain.Identity.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Points")
                        .HasColumnType("float");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Answer", b =>
                {
                    b.HasOne("Quiz.Domain.Domain_Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Event_User", b =>
                {
                    b.HasOne("Quiz.Domain.Domain_Models.Event", "Event")
                        .WithMany("Event_User")
                        .HasForeignKey("EventId");

                    b.HasOne("Quiz.Domain.Identity.ApplicationUser", "User")
                        .WithMany("Event_User")
                        .HasForeignKey("UserId");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Question", b =>
                {
                    b.HasOne("Quiz.Domain.Domain_Models.Quiz", "Quiz")
                        .WithMany("QuestionList")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Quiz", b =>
                {
                    b.HasOne("Quiz.Domain.Domain_Models.Event", "Event")
                        .WithOne("Quiz")
                        .HasForeignKey("Quiz.Domain.Domain_Models.Quiz", "EventId");

                    b.HasOne("Quiz.Domain.Domain_Models.TypeQuiz", "TypeQuize")
                        .WithOne("Quiz")
                        .HasForeignKey("Quiz.Domain.Domain_Models.Quiz", "TypeQuizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("TypeQuize");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Event", b =>
                {
                    b.Navigation("Event_User");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.Quiz", b =>
                {
                    b.Navigation("QuestionList");
                });

            modelBuilder.Entity("Quiz.Domain.Domain_Models.TypeQuiz", b =>
                {
                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Quiz.Domain.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Event_User");
                });
#pragma warning restore 612, 618
        }
    }
}
