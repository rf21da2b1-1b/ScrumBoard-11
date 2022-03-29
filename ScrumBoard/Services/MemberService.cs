using System;
using System.Collections.Generic;
using System.Linq;
using ScrumBoard.util;
using ScrumBoardLib.model;

namespace ScrumBoard.Services
{
    public class MemberService:IMemberService
    {
        private const String FileName = @"data\TeamMember.json";
        private List<TeamMember> _dataBuffer = null;
        private static int nextId = 0;


        public MemberService()
        {
            _dataBuffer = JsonFileReader.ReadJsonGeneric<TeamMember>(FileName);

            nextId = (_dataBuffer != null && _dataBuffer.Count>0)? _dataBuffer.Max(u => u.Id) + 1 : 1;
        }

        public List<TeamMember> GetAll()
        {
            return new List<TeamMember>(_dataBuffer);
        }

        public TeamMember GetById(int id)
        {
            TeamMember member = _dataBuffer.Find(m => m.Id == id);
            if (member == null)
            {
                throw new KeyNotFoundException();
            }

            return member;
        }

        public TeamMember GetScrumMaster()
        {
            TeamMember member = _dataBuffer.Find(m => m.Role == "ScrumMaster");
            if (member == null)
            {
                throw new KeyNotFoundException();
            }

            return member;
        }

        public TeamMember Create(TeamMember newMember)
        {
            newMember.Id = nextId++;
            _dataBuffer.Add(newMember);

            SaveChanges(); // remember to save changes to the json file
            return newMember;
        }

        

        public TeamMember Delete(int id)
        {
            TeamMember member = GetById(id);
            _dataBuffer.Remove(member);

            SaveChanges(); // remember to save changes to the json file
            return member;
        }

        public TeamMember Modify(TeamMember modifiedMember)
        {
            int ix = _dataBuffer.FindIndex(u => u.Id == modifiedMember.Id);
            if (ix == -1)
            {
                throw new KeyNotFoundException();
            }

            _dataBuffer[ix] = modifiedMember;

            SaveChanges(); // remember to save changes to the json file
            return modifiedMember;
        }


        /*
         * Help method for saving to a json file
         */
        private void SaveChanges()
        {
            JsonFileWriter.WriteToJsonGeneric(_dataBuffer, FileName);

        }
    }
}
