﻿using DataAccess.Repositories;
using DataAccess.Models;
using DTOS;
using lab6;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class QuestRepository : IQuestRepository
    {
        protected readonly DbSet<Quest> _dbSet;

        public QuestRepository(QuestsContext context)
        {
            context.Database.EnsureCreated();
            _dbSet = context.Set<Quest>();
        }

        public List<Quest> Find(string query)
        {
            var quests = _dbSet.Include(q => q.Availabilities).Where(q => q.Name.Contains(query)).ToList();
            return quests;
        }

        public List<Quest> GetAll()
        {
            var quests = _dbSet.ToList();
            return quests;
        }


        public Quest Create(Quest quest) 
        {
            _dbSet.Add(quest);
            return quest;
        }
        public Quest Book(int questId, TimeOnly time, int people_count, bool haveGiveCard)
        {
            var quest = _dbSet.Include(q => q.Availabilities).Where(q => q.Id == questId).ToList()[0];
            var outOfTimeRangeExist = quest.Availabilities.Any(a => a.StartTime > time || a.EndTime < time);


            if (outOfTimeRangeExist)
            {
                var availableTime = "";

                foreach (var availability in quest.Availabilities)
                {
                    availableTime += $"{availability.StartTime} - {availability.EndTime}; ";
                }

                throw new Exception($"Time is invalid. Available timer is {availableTime}");
            }
            else if (quest.ParticipantsLimit < people_count)
            {
                throw new Exception(
                    $"People count is not supported. Quest supports limit of {quest.ParticipantsLimit}.");
            }
            else if (haveGiveCard)
            {
                quest.Price = 0;
                return quest;
            }
            else
            {
                return quest;
            }
        }

        public int Delete(int questId)
        {
            var quest = _dbSet.FirstOrDefault(q => q.Id == questId);
            if (quest == null)
            {
                throw new Exception($"Quest with ID {questId} not found.");
            }

            _dbSet.Remove(quest);
            return quest.Id;
        }
            
    }
}