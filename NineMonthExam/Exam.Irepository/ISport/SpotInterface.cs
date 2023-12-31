﻿
using Exam.Domain.Sports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Irepository.ISport
{
    public interface SpotInterface
    {
        Task<int> insert(Spot p);
        Task<List<Spot>> GetAll(Spot p);
          List<Spot> GetAllExcelData(Spot p);


        Task<List<SportEntity>> BindSportByClubId(int id);
        Task<List<Spot>> BindClub();
        Task<Spot> GetById(int id);



    }
}
