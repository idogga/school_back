namespace School.Scheduler.Test.GenerateTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using NUnit.Framework;

    using School.Database;
    using School.Sheduler.Context.Facts;
    using School.Sheduler.Context.Schedule;
    using School.Sheduler.Services.Generator;

    [TestFixture]
    public class FirstGenerate : BaseTest
    {
        [SetUp]
        public void P()
        {
            _generatorService = new GeneratorService(ScheduleContext, SchoolContext);
            SetData();
        }

        private GeneratorService _generatorService;

        private void SetData()
        {
            SetScheduleLesson(DayOfWeek.Monday);
            SetScheduleLesson(DayOfWeek.Tuesday);
            SetScheduleLesson(DayOfWeek.Wednesday);
            SetScheduleLesson(DayOfWeek.Thursday);
            SetScheduleLesson(DayOfWeek.Friday);
            SetCabinetes();
            SetClass();
            SetSubject();
            SetPlansA();
            SetPlansB();
            SetPlansc();
            SetTeacher();
        }

        private void SetTeacher()
        {
            var s = SchoolContext.Subjects.ToList();
            var t1 = new Teacher("teacher1");
            t1.Subjects.Add(s[0]);
            
            var t2 = new Teacher("teacher2");
            t1.Subjects.Add(s[2]);
            t1.Subjects.Add(s[1]);

            var t3 = new Teacher("teacher3");
            t1.Subjects.Add(s[2]);
            SchoolContext.AddRange(t1, t2, t3);
            SchoolContext.SaveChanges();
        }

        private void SetPlansA()
        {
            var c1 = SchoolContext.Classes.FirstOrDefault(x=>x.Litera == 'a');
            var p1 = new PlanClass()
            {
                Id = Guid.NewGuid(),
                Class = c1,
            };
            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 2,
                Subject = SchoolContext.Subjects.First(x=>x.Name == "Biology")
            });

            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 1,
                Subject = SchoolContext.Subjects.First(x => x.Name == "Literatura")
            });

            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 3,
                Subject = SchoolContext.Subjects.First(x => x.Name == "It")
            });
            SchoolContext.Add(p1);
            SchoolContext.SaveChanges();
        }
        
        private void SetPlansB()
        {
            var c1 = SchoolContext.Classes.First(x => x.Litera == 'b');
            var p1 = new PlanClass()
            {
                Id = Guid.NewGuid(),
                Class = c1,
            };
            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 1,
                Subject = SchoolContext.Subjects.First(x => x.Name == "Biology")
            });

            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 2,
                Subject = SchoolContext.Subjects.First(x => x.Name == "Literatura")
            });

            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 3,
                Subject = SchoolContext.Subjects.First(x => x.Name == "It")
            });
            SchoolContext.Add(p1);
            SchoolContext.SaveChanges();
        }

        private void SetPlansc()
        {
            var c1 = SchoolContext.Classes.First(x => x.Litera == 'c');
            var p1 = new PlanClass()
            {
                Id = Guid.NewGuid(),
                Class = c1,
            };
            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 3,
                Subject = SchoolContext.Subjects.First(x => x.Name == "Biology")
            });

            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 1,
                Subject = SchoolContext.Subjects.First(x => x.Name == "Literatura")
            });

            p1.SubjectPlans.Add(new SubjectPlan
            {
                Count = 2,
                Subject = SchoolContext.Subjects.First(x => x.Name == "It")
            });
            SchoolContext.Add(p1);
            SchoolContext.SaveChanges();
        }

        private void SetSubject()
        {
            var s1 = new Subject
            {
                Id = Guid.NewGuid(),
                MaxPerWeek = 10,
                Name = "Biology"
            };
            var s2 = new Subject
            {
                Id = Guid.NewGuid(),
                MaxPerWeek = 20,
                Name = "Literatura"
            };
            var s3 = new Subject
            {
                Id = Guid.NewGuid(),
                MaxPerWeek = 10,
                Name = "It"
            };
            SchoolContext.AddRange(s1, s2, s3);
            SchoolContext.SaveChanges();
        }

        private void SetClass()
        {
            var c1 = new Class
            {
                Id = Guid.NewGuid(),
                Grade = 1,
                Litera = 'a'
            };
            var c2 = new Class
            {
                Id = Guid.NewGuid(),
                Grade = 2,
                Litera = 'b'
            };
            var c3 = new Class
            {
                Id = Guid.NewGuid(),
                Grade = 3,
                Litera = 'c'
            };
            SchoolContext.AddRange(c1, c2, c3);
            SchoolContext.SaveChanges();
        }

        private void SetCabinetes()
        {
            var c1 = new Cabinete
            {
                Id = Guid.NewGuid(),
                Name = "1"
            };
            var c2 = new Cabinete
            {
                Id = Guid.NewGuid(),
                Name = "2"
            };
            var c3 = new Cabinete
            {
                Id = Guid.NewGuid(),
                Name = "3"
            };
            SchoolContext.AddRange(c1, c2, c3);
            SchoolContext.SaveChanges();
        }

        private void SetScheduleLesson(DayOfWeek day)
        {
            var sl1 = new ScheduleLesson
            {
                Id = Guid.NewGuid(),
                Day = day,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(8, 45, 0)
            };
            ScheduleContext.Add(sl1);

            var sl2 = new ScheduleLesson
            {
                Id = Guid.NewGuid(),
                Day = day,
                StartTime = new TimeSpan(9, 0, 0),
                EndTime = new TimeSpan(9, 45, 0)
            };
            ScheduleContext.Add(sl2);

            var sl3 = new ScheduleLesson
            {
                Id = Guid.NewGuid(),
                Day = day,
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(10, 45, 0)
            };
            ScheduleContext.Add(sl3);

            var sl4 = new ScheduleLesson
            {
                Id = Guid.NewGuid(),
                Day = day,
                StartTime = new TimeSpan(11, 0, 0),
                EndTime = new TimeSpan(11, 45, 0)
            };
            ScheduleContext.Add(sl4);

            var sl5 = new ScheduleLesson
            {
                Id = Guid.NewGuid(),
                Day = day,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(12, 45, 0)
            };
            ScheduleContext.Add(sl5);
            ScheduleContext.SaveChanges();
        }

        [Test]
        public async Task ClassTest()
        {
            // Prepare
            var totalCount = await SchoolContext.PlanClasses.SelectMany(x => x.SubjectPlans).SumAsync(x => x.Count);
            var subjectPlans = await SchoolContext.PlanClasses.Include(x => x.SubjectPlans).ToListAsync();
            Show(subjectPlans);
            // Act
            await _generatorService.Start();

            // Assert
            var results = await ScheduleContext.Lessons.ToListAsync();
            Show(results);
            //subjectPlans.GroupBy(x => x.Subject).ToList().ForEach(
            //    x =>
            //    {
            //        var subjects = results.Where(res => res.SubjectId == x.Key.Id).ToList();
            //        subjects.Count().Should().Be(x.Sum(y=>y.Count), $"у {x.Key.Name} не совпадает");
            //    });

            results.Count.Should().Be(totalCount);
        }

        private void Show(List<FactLesson> lessons)
        {
            foreach (var lesson in lessons)
            {
                Debug.WriteLine($"{lesson.SubjectId} | {lesson.ClassId} | {lesson.Cabinete} | {lesson.TeacherId} | {lesson.Lesson}");
            }
        }
        private void Show(List<PlanClass> plans)
        {
            foreach (var plan in plans)
            {
                foreach (var subject in plan.SubjectPlans)
                {
                    Debug.WriteLine($"{plan.Class.Id} | {subject.Subject.Id} | {subject.Count}");
                }
            }
        }
    }
}