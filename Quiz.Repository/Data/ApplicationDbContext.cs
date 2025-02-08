﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Quiz.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Event_User> Events_Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Domain.Domain_Models.Quiz> Quizes { get; set; }

        public DbSet<TypeQuiz> TypeQuizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);


            modelbuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Географија на Северна Македонија",
                    Description = "Провери си го знаење за Географија во Северна Македонија",
                    StartDate = new DateTime(2025,2,15),//year,month,day
                    EndDate = new DateTime(2025,2,25),
                    
                },
                  new Event
                  {
                      Id = 2,
                      Name = "Историја на Северна Македонија",
                      Description = "Провери си го знаење за Историја во Северна Македонија",
                      StartDate = new DateTime(2025, 3, 15),//year,month,day
                      EndDate = new DateTime(2025, 3, 25),
                      
                  }

                );

            //modelbuilder.Entity<Event_User>().HasData(
            //   new Event_User
            //   {
            //       Id=1,
            //       EventId = 1,
            //       UserId = 1,
            //   },
            //    new Event_User
            //    {
            //        Id = 1,
            //        EventId = 2,
            //        UserId = 1,
            //    }// dovrshi ne znam dali kje pravi problemi


            //   );


            modelbuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "Која е највисоката планина во Северна Македонија?",
                    QuizId = 1
                },
                  new Question
                  {
                      Id = 2,
                      Text = "Која е највисоката планина во Северна Македонија?",
                      QuizId = 1
                  },
                   new Question
                   {
                       Id = 3,
                       Text = "Кое е најголемото природно езеро во Северна Македонија?",
                       QuizId = 1
                   },
                    new Question
                    {
                        Id = 4,
                        Text = "Кој национален парк е дом на загрозениот балкански рис?",
                        QuizId = 1
                    },
                     new Question
                     {
                         Id = 5,
                         Text = "Кој од наведените градови е втор по големина во Северна Македонија?",
                         QuizId = 1
                     },
                        new Question
                        {
                            Id = 6,
                            Text = "Кое античко кралство ја опфаќало територијата на модерна Северна Македонија?",
                            QuizId = 2
                        },
                     new Question
                     {
                         Id = 7,
                         Text = "Која година Северна Македонија прогласи независност од Југославија?",
                         QuizId = 2
                     },
                       new Question
                       {
                           Id = 8,
                           Text = "Која позната историска личност, родена во Пела, Грција," +
                           " имаше значително влијание врз регионот на Северна Македонија?",
                           QuizId = 2
                       },
                      new Question
                      {
                          Id = 9,
                          Text = "Која империја владеела со територијата на модерна Северна Македонија над 500 години?",
                          QuizId = 2
                      },
                     new Question
                     {
                         Id = 10,
                         Text = "Како се викаше договорот со кој се реши долгогодишниот " +
                         "спор за името меѓу Грција и Северна Македонија во 2018 година?",
                         QuizId = 2
                     }

                );

            modelbuilder.Entity<Domain.Domain_Models.Quiz>().HasData(
              new Domain.Domain_Models.Quiz
              {
                  Id = 1,
                  TypeQuizeId = 1,
                  EventId = 1,
                  
              },
                new Domain.Domain_Models.Quiz
                {
                    Id = 2,
                    TypeQuizeId = 2,
                    EventId = 2
                }


              );

            modelbuilder.Entity<TypeQuiz>().HasData(
               new TypeQuiz
               {
                   Id = 1,
                   Type = "Географија",
                   
               },
               new TypeQuiz
               {
                   Id = 2,
                   Type = "Историја",
                   
               }


               );

            modelbuilder.Entity<Answer>().HasData(
                new Answer {
                    Id = 1,
                    QuestionId = 1,
                    Text = "Јакупица",
                    isCorrect = false
                },
                 new Answer
                 {
                     Id = 2,
                     QuestionId = 1,
                     Text = "Шар Планина",
                     isCorrect = false
                 },
                   new Answer
                   {
                       Id = 3,
                       QuestionId = 1,
                       Text = "Кораб",
                       isCorrect = true
                   },
                     new Answer
                     {
                         Id = 4,
                         QuestionId = 1,
                         Text = "Пелистер",
                         isCorrect = false
                     },
                new Answer
                {
                    Id = 5,
                    QuestionId = 2,
                    Text = "Треска",
                    isCorrect = false
                },
                 new Answer
                 {
                     Id = 6,
                     QuestionId = 2,
                     Text = "Црна Река",
                     isCorrect = false
                 },
                 new Answer
                 {
                     Id = 7,
                     QuestionId = 2,
                     Text = "Брегалница",
                     isCorrect = false
                 },
                  new Answer
                  {
                      Id = 8,
                      QuestionId = 2,
                      Text = "Вардар",
                      isCorrect = true
                  },
                   new Answer
                   {
                       Id = 9,
                       QuestionId = 3,
                       Text = "Преспа",
                       isCorrect = false
                   },
                     new Answer
                     {
                         Id = 10,
                         QuestionId = 3,
                         Text = "Дојран",
                         isCorrect = false
                     },
                      new Answer
                      {
                          Id = 11,
                          QuestionId = 3,
                          Text = "Охрид",
                          isCorrect = true
                      },
                      new Answer
                      {
                          Id = 12,
                          QuestionId = 3,
                          Text = "Тиквеш",
                          isCorrect = false
                      },
                       new Answer
                       {
                           Id = 13,
                           QuestionId = 4,
                           Text = "Галичица",
                           isCorrect = false
                       },
                         new Answer
                         {
                             Id = 14,
                             QuestionId = 4,
                             Text = "Маврово",
                             isCorrect = true
                         },
                          new Answer
                          {
                              Id = 15,
                              QuestionId = 4,
                              Text = "Јасен",
                              isCorrect = false
                          },
                             new Answer
                             {
                                 Id = 16,
                                 QuestionId = 4,
                                 Text = "Пелистер",
                                 isCorrect = false
                             },
                      new Answer
                      {
                          Id = 17,
                          QuestionId = 5,
                          Text = "Битола",
                          isCorrect = true
                      },
                        new Answer
                        {
                            Id = 18,
                            QuestionId = 5,
                            Text = "Охрид",
                            isCorrect = false
                        },
                        new Answer
                        {
                            Id = 19,
                            QuestionId = 5,
                            Text = "Куманово",
                            isCorrect = false
                        },
                        new Answer
                        {
                            Id = 20,
                            QuestionId = 5,
                            Text = "Тетово",
                            isCorrect = false
                        },
                         new Answer
                         {
                             Id = 21,
                             QuestionId = 6,
                             Text = "Дарданиа",
                             isCorrect = false
                         },
                          new Answer
                          {
                              Id = 22,
                              QuestionId = 6,
                              Text = "Пеониа",
                              isCorrect = true
                          },
                            new Answer
                            {
                                Id = 23,
                                QuestionId = 6,
                                Text = "Алирија",
                                isCorrect = false
                            },
                          new Answer
                          {
                              Id = 24,
                              QuestionId = 6,
                              Text = "Англија",
                              isCorrect = false
                          },
                           new Answer
                           {
                               Id = 25,
                               QuestionId = 7,
                               Text = "1989",
                               isCorrect = false
                           },
                           new Answer
                           {
                               Id = 26,
                               QuestionId = 7,
                               Text = "1995",
                               isCorrect = false
                           },
                            new Answer
                            {
                                Id = 27,
                                QuestionId = 7,
                                Text = "1991",
                                isCorrect = true
                            },
                             new Answer
                             {
                                 Id = 28,
                                 QuestionId = 7,
                                 Text = "2001",
                                 isCorrect = false
                             },
                              new Answer
                              {
                                  Id = 29,
                                  QuestionId = 8,
                                  Text = "Филип II Македонски",
                                  isCorrect = false
                              },
                              
                                new Answer
                                {
                                    Id = 30,
                                    QuestionId = 8,
                                    Text = "Александар Македонски",
                                    isCorrect = true
                                },
                                
                                 new Answer
                                 {
                                     Id = 31,
                                     QuestionId = 8,
                                     Text = "Јустинијан I",
                                     isCorrect = false
                                 },
                                 
                        new Answer
                        {
                            Id = 32,
                            QuestionId = 8,
                            Text = "Скендербег",
                            isCorrect = false
                        },
                        
                         new Answer
                         {
                             Id = 33,
                             QuestionId = 9,
                             Text = "Римската империја",
                             isCorrect = false
                         },
                         
                           new Answer
                           {
                               Id = 34,
                               QuestionId = 9,
                               Text = "Византиска империја",
                               isCorrect = false
                           },
                           
                             new Answer
                             {
                                 Id = 35,
                                 QuestionId = 9,
                                 Text = "Отоманската империја",
                                 isCorrect = true
                             },
                             
                                new Answer
                                {
                                    Id = 36,
                                    QuestionId = 9,
                                    Text = "Австро - унгарската империја",
                                    isCorrect = false
                                },
                                
                          new Answer
                          {
                              Id = 37,
                              QuestionId = 10,
                              Text = "Скопски договор",
                              isCorrect = false
                          },
                           new Answer
                           {
                               Id = 38,
                               QuestionId = 10,
                               Text = "Договорот од Преспа",
                               isCorrect = true
                           },
                            new Answer
                            {
                                Id = 39,
                                QuestionId = 10,
                                Text = "Балкански договор",
                                isCorrect = false
                            },
                             new Answer
                             {
                                 Id = 40,
                                 QuestionId = 10,
                                 Text = "Охридски рамковен договор",
                                 isCorrect = false
                             }
                );
        }


    }
}
