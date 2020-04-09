using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source.Entities;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        List<Team> Teams = new List<Team>();
        List<Player> Players = new List<Player>();

        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (Teams.Any(x => x.Id == id))
            {
                throw new UniqueIdentifierException();
            }

            Teams.Add(new Team(id, name, createDate, mainShirtColor, secondaryShirtColor));
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if (Players.Any(x => x.Id == id))
            {
                throw new UniqueIdentifierException();
            }
            if (!Teams.Any(x => x.Id == teamId))
            {
                throw new TeamNotFoundException();
            }

            Players.Add(new Player(id, teamId, name, birthDate, skillLevel, salary));
        }

        public void SetCaptain(long playerId)
        {
            if (!Players.Any(x => x.Id == playerId))
            {
                throw new PlayerNotFoundException();
            }
            foreach (Player player in Players)
            {
                player.Captain = player.Id == playerId;
            }
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
            {
                throw new TeamNotFoundException();
            }

            Player captain = Players.FirstOrDefault(x => x.TeamId == teamId && x.Captain);

            if (captain is null)
            {
                throw new CaptainNotFoundException();
            }

            return captain.Id;
        }

        public string GetPlayerName(long playerId)
        {
            foreach (Player player in Players)
            {
                if (player.Id == playerId)
                {
                    return player.Name;
                }
            }
            throw new PlayerNotFoundException();
        }

        public string GetTeamName(long teamId)
        {
            foreach (Team team in Teams)
            {
                if (team.Id == teamId)
                {
                    return team.Name;
                }
            }
            throw new TeamNotFoundException();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
            {
                throw new TeamNotFoundException();
            }
            return Players.Where(x => x.TeamId == teamId).OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
            {
                throw new TeamNotFoundException();
            }
            return Players
                .Where(x => x.TeamId == teamId)
                .OrderByDescending(x => x.SkillLevel)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
            {
                throw new TeamNotFoundException();
            }
            return Players
                .Where(x => x.TeamId == teamId)
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public List<long> GetTeams()
        {
            if (!Teams.Any())
            {
                return new List<long>();
            }
            return Teams.OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (!Teams.Any(x => x.Id == teamId))
            {
                throw new TeamNotFoundException();
            }
            return Players
                .Where(x => x.TeamId == teamId)
                .OrderByDescending(x => x.Salary)
                .ThenBy(x => x.Id)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            if (!Players.Any(x => x.Id == playerId))
            {
                throw new PlayerNotFoundException();
            }
            return Players.Where(x => x.Id == playerId).Select(x => x.Salary).FirstOrDefault();
        }

        public List<long> GetTopPlayers(int top)
        {
            if (!Players.Any())
            {
                return new List<long>();
            }
            return Players
                .OrderByDescending(x => x.SkillLevel)
                .ThenBy(x => x.Id)
                .Select(x => x.Id)
                .Take(top)
                .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if (!Teams.Any(x => x.Id == teamId) || !Teams.Any(x => x.Id == visitorTeamId))
            {
                throw new TeamNotFoundException();
            }

            Team homeTeam = Teams.FirstOrDefault(x => x.Id == teamId);
            Team visitorTeam = Teams.FirstOrDefault(x => x.Id == visitorTeamId);

            if (homeTeam.MainShirtColor == visitorTeam.MainShirtColor)
            {
                return visitorTeam.SecondaryShirtColor;
            }
            else
            {
                return visitorTeam.MainShirtColor;
            }
        }
    }
}
