using AutoMapper;
using CommanderAPI.Domain.Commander.Abstract;
using CommanderAPI.Dtos;
using CommanderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CommanderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _commanderRepo = commanderRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _commanderRepo.GetCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _commanderRepo.GetCommandById(id);
            
            if(commandItem == null)
            {
                return NotFound();                
            }

            return Ok(_mapper.Map<CommandReadDto>(commandItem));

        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreate)
        {
            var commandModel = _mapper.Map<Command>(commandCreate);
            
            _commanderRepo.CreateCommand(commandModel);
            _commanderRepo.SaveChanges();
            
            var commandResult = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandResult.Id }, commandResult);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdate)
        {
            var commandItem = _commanderRepo.GetCommandById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdate, commandItem);
            _commanderRepo.UpdateCommand(commandItem);
            _commanderRepo.SaveChanges();
            
            return NoContent();
        }
    }
}
