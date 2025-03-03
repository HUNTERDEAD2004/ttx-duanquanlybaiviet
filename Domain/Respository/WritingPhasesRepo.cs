using AppDomain.Object;
using Azure.Messaging;
using Domain.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Services.DTO.WritingPhases;
using Services.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Respository
{
    public class WritingPhasesRepo : IWritingPhasesRespository
    {
        private readonly QuanLyBaiVietDbcontext _db;

        

        public WritingPhasesRepo(QuanLyBaiVietDbcontext db)
        {
            _db = db;
        }

        public async Task<bool> CreateWP(WritingPhasesDTO wpdto)
        {
            if (wpdto == null)
            {
                return false;
            }
            else
            {
                var createWP = new WritingPhases
                {
                    Name = wpdto.Name,
                    AmountArticles = wpdto.AmountArticles,
                    StartDate = wpdto.StartDate,
                    EndDate = wpdto.EndDate,
                    CreateAt = wpdto.CreateAt,
                    ModifiedAt = wpdto.ModifiedAt,
                    Is_Opening_registration = wpdto.Is_Opening_registration,

                };
                _db.WritingPhases.Add(createWP);
                _db.SaveChanges();

                return true;
            }
        }

        public async Task<bool> DeleteWP(int id)
        {
            var deleteWP = await _db.WritingPhases.FindAsync(id);
            if (deleteWP != null)
            {
                _db.WritingPhases.Remove(deleteWP);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<WritingPhasesDTO>> GetAllWP()
        {
            var query = _db.WritingPhases
                .Include(x => x.Articles)
                .Include(x => x.UserRegistrationPeriods)
                .AsQueryable();
            var WritingPhase = await query.Select(x => new WritingPhasesDTO
            {
                WritingPhaseID = x.WritingPhaseID,
                Name = x.Name,
                AmountArticles = x.AmountArticles,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                CreateAt = x.CreateAt,
                ModifiedAt = x.ModifiedAt,
                Is_Opening_registration= x.Is_Opening_registration,
                RegistrationPeriodID = x.RegistrationPeriodID,
            }).ToListAsync();

            return WritingPhase;
        }

        public async Task<WritingPhasesDTO> GetWPById(int id)
        {
            var query = await _db.WritingPhases
                .Include(x => x.Articles)
                .Include (x => x.UserRegistrationPeriods)
                .FirstOrDefaultAsync(x=> x.WritingPhaseID == id);

            if (query == null)
            {
                return null;
            }
            return new WritingPhasesDTO
            {
                Name = query.Name,
                AmountArticles = query.AmountArticles,
                StartDate = query.StartDate,
                EndDate = query.EndDate,
                CreateAt = query.CreateAt,
                ModifiedAt = query.ModifiedAt,
                Is_Opening_registration = query.Is_Opening_registration,
                RegistrationPeriodID = query.RegistrationPeriodID,
            };
        }

        public async Task<bool> UpdateWP(WritingPhasesDTO wpdto)
        {
            if (wpdto == null)
            {
               return false;
            }
            else
            {
                var writingphases = await _db.WritingPhases
                    .Include(x => x.Articles)
                    .Include(x => x.UserRegistrationPeriods)
                    .FirstOrDefaultAsync(x => x.WritingPhaseID==wpdto.WritingPhaseID);
                if (writingphases == null)
                {
                    return false;
                }else
                {
                    writingphases.Name = wpdto.Name;
                    writingphases.AmountArticles = wpdto.AmountArticles;
                    writingphases.StartDate = wpdto.StartDate;
                    writingphases.EndDate = wpdto.EndDate;
                    writingphases.CreateAt = wpdto.CreateAt;
                    writingphases.ModifiedAt = wpdto.ModifiedAt;
                    writingphases.Is_Opening_registration = wpdto.Is_Opening_registration;
                    writingphases.RegistrationPeriodID = wpdto.RegistrationPeriodID;

                    _db.WritingPhases.Update(writingphases);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return true;
            }

        }
    }
}
