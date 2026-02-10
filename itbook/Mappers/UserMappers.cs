using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbook.Dtos;
using itbook.Models;

namespace itbook.Mappers
{
    public static class UserMappers
    {
        // Response
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Username = userModel.Username,
                Fullname = userModel.Fullname,
            };
        }

        public static LikeBookDto ToLikeBookDto(this LikeBook likeBookModel)
        {
            return new LikeBookDto
            {
                Id = likeBookModel.Id,
                UserId = likeBookModel.UserId,
                BookId = likeBookModel.BookId,
                LikedDateTime = likeBookModel.LikedDateTime,
                User = likeBookModel.User?.ToUserDto(),
            };
        }

        // Request
        public static User ToUserFromCreateDto(this RegisterRequestDto registerRequestDto)
        {
            return new User
            {
                Username = registerRequestDto.Username,
                Password = registerRequestDto.Password,
                Fullname = registerRequestDto.Fullname,
            };
        }

        public static LikeBook ToLikeBookFromCreateDto(this LikeBookRequestDto likeBookRequestDto)
        {
            return new LikeBook
            {
                UserId = likeBookRequestDto.UserId,
                BookId = likeBookRequestDto.BookId,
            };
        }
    }
}
