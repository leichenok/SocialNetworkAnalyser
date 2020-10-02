﻿using SocialNetworkAnalyser.Data.Contexts;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class FriendshipRepository : RepositoryBase, IFriendshipRepository
    {
        public FriendshipRepository(AppContext context) 
            : base(context)
        {
        }


        public Friendship Get(Guid id, Guid dataSetID)
        {
            try
            {
                return Context.Friendships.Include(u => u.Users).FirstOrDefault(f => f.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
        public List<Friendship> GetAll(Guid dataSetID)
        {
            try
            {
                return Context.Friendships.Include(u => u.Users).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Add(IEnumerable<Friendship> friendships)
        {
            try
            {
                Context.Friendships.AddRange(friendships);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public double GetAverageFriendsCountForEachUser(Guid dataSetId)
        {
            var average = Context.Friendships.Where(f => f.DataSetId == dataSetId).Average(f => f.Users.Count);
            return average;
        }
    }
}
