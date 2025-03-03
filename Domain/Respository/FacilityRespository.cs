using AppDomain.Object;
using Common.Response;
using Domain.Data.Enum;
using Domain.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.DTO.Articles;
using Services.DTO.Categories;
using Services.DTO.Facility;
using Services.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Respository
{
    public class FacilityRespository : IFacilityRespository
    {
        private readonly QuanLyBaiVietDbcontext _appDbContext;

        public FacilityRespository(QuanLyBaiVietDbcontext quanLyBaiVietDbcontext)
        {
            _appDbContext = quanLyBaiVietDbcontext;
        }

        public async Task<ResponseDTO<FacilityDTO>> CreateFacilities(CreateFacilitiesRequest request)
        {
            if (request == null)
            {
                return new ResponseDTO<FacilityDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var createFacility = new Facility
                {
                    Name = request.Name
                };

                _appDbContext.Facilities.Add(createFacility);
                _appDbContext.SaveChanges();

                return new ResponseDTO<FacilityDTO>
                {
                    DataResponse = new FacilityDTO
                    {
                        Name = request.Name
                    },
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo chủ đề thành công."
                };
            }
        }

        public async Task<ResponseDTO<bool>> DeleteFacilities(int id)
        {
            var deleteFacility = await _appDbContext.Facilities.FindAsync(id);
            if (deleteFacility != null)
            {
                _appDbContext.Facilities.Remove(deleteFacility);
                _appDbContext.SaveChanges();
                return new ResponseDTO<bool>
                {
                    DataResponse = true,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa thành công."
                };
            }
            return new ResponseDTO<bool>
            {
                DataResponse = false,
                Status = StatusCodes.Status400BadRequest,
                Message = "Xóa thất bại."
            };
        }

        public async Task<List<FacilityDTO>> GetAllFacilities()
        {
            var query = _appDbContext.Facilities
                .AsQueryable();

            var Facilities = await query.Select(c => new FacilityDTO
            {
                Name = c.Name,
            }).ToListAsync();

            return Facilities;
        }

        public async Task<FacilityDTO> GetInfoFacilitiesById(int id)
        {
            var query = await _appDbContext.Facilities
                 .FirstOrDefaultAsync(a => a.FacilityId == id);
            if (query == null)
            {
                return null;
            }

            return new FacilityDTO
            {
                Name = query.Name,
            };
        }

        public async Task<ResponseDTO<FacilityDTO>> UpdateFacilities(UpdateFacilitiesRequest request)
        {
            if (request == null)
            {
                return new ResponseDTO<FacilityDTO>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            else
            {
                var facility = await _appDbContext.Facilities
                .FirstOrDefaultAsync(a => a.FacilityId == request.FacilityId);

                if (facility == null)
                {
                    return new ResponseDTO<FacilityDTO>
                    {
                        DataResponse = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy Co so."
                    };
                }

                facility.Name = request.Name;

                _appDbContext.Facilities.Update(facility);

                await _appDbContext.SaveChangesAsync();

                return new ResponseDTO<FacilityDTO>
                {
                    DataResponse = new FacilityDTO
                    {
                        Name = request.Name,
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật chủ đề thành công."
                };
            }
        }
    }
}
