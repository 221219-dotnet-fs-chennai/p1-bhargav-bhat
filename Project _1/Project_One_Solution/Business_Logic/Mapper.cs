﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class Mapper
    {
        public static Models.Trainer Map(Fluent_API.Entities.Trainer t)
        {
            return new Models.Trainer()
            {

                firstName = t.FirstName,
                lastName = t.LastName,
                Gender = t.Gender,
                Email = t.Email,
                Phone = t.Phone,
                City = t.City,
                State = t.State,
                Country = t.Country,
                Aboutme = t.AboutMe

            };
        }

        public static IEnumerable<Models.Trainer> Map(IEnumerable<Fluent_API.Entities.Trainer> trainers)
        {
            return trainers.Select(Map);
        }

        public static Models.Skills Map(Fluent_API.Entities.Skill s)
        {
            return new Models.Skills()
            {
                Id = s.Id1,
                skillName = s.SkillName
            };
        }

        public static IEnumerable<Models.Skills> Map(IEnumerable<Fluent_API.Entities.Skill> skills)
        {
            return skills.Select(Map);
        }

        public static Models.WorkE Map(Fluent_API.Entities.WorkExperience w)
        {
            return new Models.WorkE()
            {
                Id = w.Id3,
                Company_Name = w.CompanyName,
                Role = w.Role,
                StartDate = w.StartDate,
                EndDate = w.EndDate,
                Description = w.Description
            };
        }
        public static IEnumerable<Models.WorkE> Map(IEnumerable<Fluent_API.Entities.WorkExperience> workExperiences)
        {
            return workExperiences.Select(Map);
        }

        public static Models.Educate Map(Fluent_API.Entities.Education e)
        {
            return new Models.Educate()
            {
                Id = e.Id2,
                College_Uni = e.CollegeUniversity,
                Degree = e.Degree,
                Start_Date = e.StartDate,
                End_Date = e.EndDate,
                Descriptions = e.Description
            };
        }

        public static IEnumerable<Models.Educate> Map(IEnumerable<Fluent_API.Entities.Education> educations)
        {
            return educations.Select(Map);
        }

        public static Models.Additional Map(Fluent_API.Entities.AdditionalDetail ad)
        {
            return new Models.Additional()
            {
                Id = ad.Id4,
                Title = ad.Title,
                Achievments = ad.Achievements,
                Publications = ad.Publications,
                Volunteering_Experiences = ad.VolunteeringExperiences
            };
        }

        public static IEnumerable<Models.Additional> Map(IEnumerable<Fluent_API.Entities.AdditionalDetail> additionalDetails)
        {
            return additionalDetails.Select(Map);
        }

        public static Trainer MapTrainer(Models.Trainer at)
        {
            return new Trainer()
            {
                firstName = at.firstName,
                lastName = at.lastName,
                Gender = at.Gender,
                Email = at.Email,
                Password = at.Password,
                Phone = at.Phone,
                City = at.City,
                State = at.State,
                Country = at.Country,
                Aboutme = at.Aboutme
            };
        }
    }
}
