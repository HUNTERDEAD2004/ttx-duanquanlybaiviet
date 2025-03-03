using AppDomain.Object;
using Domain.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Services.DTO.RegistrationPeriods;
using Services.DTO.WritingPhases;
using Services.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Respository
{
    public class RegistrationPeriodsRepo : IRegistrationPeriodsRespository
    {
        private readonly QuanLyBaiVietDbcontext _db;
        public RegistrationPeriodsRepo(QuanLyBaiVietDbcontext db)
        {
            _db = db;
        }

        public async Task<bool> CreateRegistrationPe(RegistrationPeriodsDTO registrationPeriodsDTO)
        {
            if (registrationPeriodsDTO == null)
            {
                return false;
            }
            else
            {
                var createRP = new RegistrationPeriods
                {
                    Name = registrationPeriodsDTO.Name,
                    RegistrationStart = registrationPeriodsDTO.RegistrationStart,
                    RegistrationEnd = registrationPeriodsDTO.RegistrationEnd,
                    User_Training_Facility_Code = registrationPeriodsDTO.User_Training_Facility_Code,
                    CreateAt = registrationPeriodsDTO.CreateAt,
                    ModifiedAt = registrationPeriodsDTO.ModifiedAt,
                    StartDate = registrationPeriodsDTO.StartDate,
                    EndDate = registrationPeriodsDTO.EndDate,
                    Is_Opening_registration = registrationPeriodsDTO.Is_Opening_registration,
                };
                _db.RegistrationPeriods.Add(createRP);
                _db.SaveChanges();

                return true;
            }
        }

        public async Task<bool> DeleteRegistrationPe(int id)
        {
            var deleteRP = await _db.RegistrationPeriods.FindAsync(id);
            if (deleteRP != null)
            {
                _db.RegistrationPeriods.Remove(deleteRP);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<RegistrationPeriodsDTO>> GetAllRegistrations()
        {
            var query = _db.RegistrationPeriods

            .AsQueryable();
            var RegistrationPeriods = await query.Select(x => new RegistrationPeriodsDTO
            {
                RegistrationPeriodID = x.RegistrationPeriodID,
                Name = x.Name,
                RegistrationStart = x.RegistrationStart,
                RegistrationEnd = x.RegistrationEnd,
                User_Training_Facility_Code = x.User_Training_Facility_Code,
                CreateAt = x.CreateAt,
                ModifiedAt = x.ModifiedAt,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Is_Opening_registration = x.Is_Opening_registration,
            }).ToListAsync();

            return RegistrationPeriods;

        }

        public async Task<RegistrationPeriodsDTO> GetRegistrationsById(int id)
        {
            var query = await _db.RegistrationPeriods
                .Include(x => x.WritingPhases)
                .FirstOrDefaultAsync(x => x.RegistrationPeriodID == id);

            if (query == null)
            {
                return null;
            }
            return new RegistrationPeriodsDTO
            {
                Name = query.Name,
                RegistrationStart = query.RegistrationStart,
                RegistrationEnd = query.RegistrationEnd,
                User_Training_Facility_Code = query.User_Training_Facility_Code,
                CreateAt = query.CreateAt,
                ModifiedAt = query.ModifiedAt,
                StartDate = query.StartDate,
                EndDate = query.EndDate,
                Is_Opening_registration = query.Is_Opening_registration,
            };
        }

        public async Task<bool> UpdateRegistrationPe(RegistrationPeriodsDTO registrationPeriodsDTO)
        {
            if (registrationPeriodsDTO == null)
            {
                return false;
            }
            else
            {
                var registrationPeriods = await _db.RegistrationPeriods
                    .Include(x => x.WritingPhases)

                    .FirstOrDefaultAsync(x => x.RegistrationPeriodID == registrationPeriodsDTO.RegistrationPeriodID);
                if (registrationPeriods == null)
                {
                    return false;
                }
                else
                {
                    registrationPeriods.Name = registrationPeriodsDTO.Name;
                    registrationPeriods.RegistrationStart = registrationPeriodsDTO.RegistrationStart;
                    registrationPeriods.RegistrationEnd = registrationPeriodsDTO.RegistrationEnd;
                    registrationPeriods.User_Training_Facility_Code = registrationPeriodsDTO.User_Training_Facility_Code;
                    registrationPeriods.CreateAt = registrationPeriodsDTO.CreateAt;
                    registrationPeriods.ModifiedAt = registrationPeriodsDTO.ModifiedAt;
                    registrationPeriods.StartDate = registrationPeriodsDTO.StartDate;
                    registrationPeriods.EndDate = registrationPeriodsDTO.EndDate;
                    registrationPeriods.Is_Opening_registration = registrationPeriodsDTO.Is_Opening_registration;

                    _db.RegistrationPeriods.Update(registrationPeriods);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return true;
            }
        }
    }
}
