using Microsoft.EntityFrameworkCore;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly ApplicationDbContext db;

        public PlanningService(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public async Task Plan(int cardListId)
        {
            List<PlanCard> planCards = await GetPlanCardsAsync(cardListId);
            int n = planCards.Count();
            planCards.Sort(Comparator);
            Queue<PlanCard> s = new Queue<PlanCard>();
            List<int> result = new List<int>();
            for (int i = n - 1; i >= 0; --i)
            {
                TimeSpan t = planCards[i].End - (i != 0 ? planCards[i - 1].End : DateTimeOffset.MinValue);
                s.Enqueue(planCards[i]);
                //s.insert(make_pair(a[i].second, i));
                while (t != TimeSpan.Zero && s.Count() != 0)
                {
                    var it = s.Dequeue();
                    //t_s::iterator it = s.begin();
                    if (it.Duration <= t.Minutes)
                    {
                        t -= new TimeSpan(0, (int)it.Duration, 0);
                       // result.Add(i);
                    }
                    else
                    {
                       // s.insert(make_pair(it->first - t, it->second));
                        t = TimeSpan.Zero;
                    }
                }
            }
        }
        
        private async Task<List<PlanCard>> GetPlanCardsAsync(int cardListId)
        {
            return await db.PlanCards.Where(pc => pc.CardsListId == cardListId).ToListAsync();
        }

        private static int Comparator(PlanCard first, PlanCard second)
        {
            return (first.End.CompareTo(second.End));
        }
    }
}
