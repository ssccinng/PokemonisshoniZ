﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonisshoniZ.Data;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231204013440_addMatchRound1")]
    partial class addMatchRound1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasComment("头像");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasComment("城市");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime(6)")
                        .HasComment("生日");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("GSNum")
                        .HasColumnType("int")
                        .HasComment("GS号");

                    b.Property<string>("HomeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasComment("游戏名");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasComment("昵称");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("QQ")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasComment("QQ号");

                    b.Property<DateTime>("Registertime")
                        .HasColumnType("datetime(6)")
                        .HasComment("注册时间");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int")
                        .HasComment("训练家id");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AllowGuest")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<bool>("HasUsage")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("MatchEndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MatchMode")
                        .HasColumnType("int");

                    b.Property<int>("MatchOnline")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchStartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MatchStatus")
                        .HasColumnType("int");

                    b.Property<int>("MatchType")
                        .HasColumnType("int");

                    b.Property<int>("MaxPlayerNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("NeedCheck")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("NotShow")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RoundIdx")
                        .HasColumnType("int");

                    b.Property<int>("TeamNumberLimit")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PCLMatches");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLMatchPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Declaration")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PCLMatchId")
                        .HasColumnType("int");

                    b.Property<int>("PreTeamId")
                        .HasColumnType("int");

                    b.Property<string>("QQ")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ShadowId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(270)");

                    b.HasKey("Id");

                    b.HasIndex("PCLMatchId");

                    b.HasIndex("PreTeamId");

                    b.HasIndex("UserId");

                    b.ToTable("PCLMatchPlayer");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLMatchRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AcceptTeamSubmit")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("BO")
                        .HasColumnType("int");

                    b.Property<bool>("CanSeeOppTeam")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("DrawScore")
                        .HasColumnType("int");

                    b.Property<int>("EliminationType")
                        .HasColumnType("int");

                    b.Property<int>("GroupCnt")
                        .HasColumnType("int");

                    b.Property<bool>("IsGroup")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockTeam")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LoseScore")
                        .HasColumnType("int");

                    b.Property<int>("PCLMatchId")
                        .HasColumnType("int");

                    b.Property<int>("PCLRoundState")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("PCLRoundType")
                        .HasColumnType("int");

                    b.Property<int>("RoundPromotion")
                        .HasColumnType("int");

                    b.Property<int>("SwissCount")
                        .HasColumnType("int");

                    b.Property<int>("SwissPromotionType")
                        .HasColumnType("int");

                    b.Property<int>("Swissidx")
                        .HasColumnType("int");

                    b.Property<int>("WinScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PCLMatchId");

                    b.ToTable("PCLMatchRound");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLPokemon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("PSText")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<long>("PokeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PCLPokemons");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLPokemonBox", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("BoxIdx")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PCLPokemonIds")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PCLPokemonBoxes");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PSUsername", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PSName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PSUsername");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PokeTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<bool>("Islock")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PSText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PokemonIds")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<int>("TeamType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PokeTeams");
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
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", null)
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

                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLMatch", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLMatchPlayer", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.PCLMatch", null)
                        .WithMany("PCLMatchPlayerList")
                        .HasForeignKey("PCLMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonisshoniZ.Data.PokeTeam", "PreTeam")
                        .WithMany()
                        .HasForeignKey("PreTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreTeam");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLMatchRound", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.PCLMatch", null)
                        .WithMany("PCLMatchRoundList")
                        .HasForeignKey("PCLMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLPokemon", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLPokemonBox", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PSUsername", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PokeTeam", b =>
                {
                    b.HasOne("PokemonisshoniZ.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokemonisshoniZ.Data.PCLMatch", b =>
                {
                    b.Navigation("PCLMatchPlayerList");

                    b.Navigation("PCLMatchRoundList");
                });
#pragma warning restore 612, 618
        }
    }
}
