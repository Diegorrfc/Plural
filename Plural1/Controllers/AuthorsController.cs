using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plural1.Entities;
using Plural1.Helpers;
using Plural1.Models;
using Plural1.ResourceParameters;
using Plural1.Services;

namespace Plural1.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private ICourseLibraryRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthor()
        {
           var authorsFromRepository = _repository.GetAuthors();

           
           List<AuthorDto>  authorsDto = _mapper.Map<List<AuthorDto>>(authorsFromRepository);

           return Ok(authorsDto);
        }
        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthor([FromQuery]AuthorResourceParamers authorResourceParamers)
        {
            if (authorResourceParamers == null)
                throw new ArgumentNullException(nameof(authorResourceParamers));

            var authorsFromRepository = _repository.GetAuthors(authorResourceParamers);

            List<AuthorDto> authorsDto = _mapper.Map<List<AuthorDto>>(authorsFromRepository);

            return Ok(authorsDto);
        }
        [Route("authorId", Name = "GetAuthor")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            if (authorId == Guid.Empty)
                return BadRequest();

           return _mapper.Map<AuthorDto>(_repository.GetAuthor(authorId));
        }
        public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto authorForCreationDto)
        {
            if (authorForCreationDto == null)
                return BadRequest();

           var author =  _mapper.Map<Author>(authorForCreationDto);
           var authorToReturn = _mapper.Map<AuthorDto>(author);
           _repository.CreateAuthor(author);

            return CreatedAtRoute("", new { authorId = author.Id }, authorToReturn);

        }
    }
}
