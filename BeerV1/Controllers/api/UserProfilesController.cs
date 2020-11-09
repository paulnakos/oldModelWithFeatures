using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BeerV1.Dtos;
using BeerV1.Models;

namespace BeerV1.Controllers.api
{
    public class UserProfilesController : ApiController
    {
        private ApplicationDbContext context;

        public UserProfilesController()
        {
            context = new ApplicationDbContext();
        }

        //Get api/userprofiles
        public IHttpActionResult GetUsers()
        {
            var users = context.Users.ToList()
                .Select(Mapper.Map<User, UserDto>);

            return Ok(users);
        }

        //Get /api/userprofiles/id
        public IHttpActionResult GetUser(int id)
        {
            var user = context.Users.SingleOrDefault(u => u.UserID == id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<User, UserDto>(user));
        }

        //Post api/userprofiles
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var user = Mapper.Map<UserDto, User>(userDto);
            context.Users.Add(user);
            context.SaveChanges();

            userDto.UserID = user.UserID;
            return Created(/*new Uri(Request.RequestUri + "/" + user.UserID),*/"api/userprofiles/" + user.UserID, userDto);
        }

        //Update api/userprofiles/id
        [HttpPut]
        public IHttpActionResult UpdateUser(int id,UserDto userDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var userDb = context.Users.SingleOrDefault(u => u.UserID == id);

            if (userDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(userDto, userDb);
            context.SaveChanges();

            return Ok(userDto);
        }

        //delete api/userprofiles/id
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var userDb = context.Users.SingleOrDefault(u => u.UserID == id);

            if (userDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Users.Remove(userDb);
            context.SaveChanges();


            return Ok();
        }
    }
}
