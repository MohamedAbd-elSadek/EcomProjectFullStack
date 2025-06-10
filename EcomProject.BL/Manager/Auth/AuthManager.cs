using EcomProject.BL.DTOs.Auth;
using EcomProject.BL.DTOs.Email;
using EcomProject.BL.Manager.EmailSender;
using EcomProject.BL.Manager.TokenGenerator;
using EcomProject.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.Auth
{
    public class AuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<User> _signInManager;
        private readonly IGenerateToken generateToken;
        public AuthManager(UserManager<User> userManager, IEmailSender emailSender, SignInManager<User> signInManager, IGenerateToken generateToken)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
            this.generateToken = generateToken;
        }

        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO == null)
            {
                return null;
            }
            if ( await _userManager.FindByNameAsync(registerDTO.UserName) is not null)
            {
                return "this username is already registered";
            }
            if (await _userManager.FindByEmailAsync(registerDTO.Email) is not null)
            {
                return "this email is already registered";
            }
            User newUser = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
            };
            var result = await _userManager.CreateAsync(newUser,registerDTO.Password);
            if (!result.Succeeded)
            {
                return result.Errors.ToList()[0].Description;
            }
            // email confirmation
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            await SendEmail(newUser.Email, token, "active", "ActivateAccount", "Please Active your account , click on link to active");


                return "done";
            

        }

        public async Task SendEmail(string email, string code,string component, string subject,string message)
        {
            var result = new EmailDTO(email, "robinvanhood20@gmail.com", subject, EmailStringBody.send(email,code,component,message));

            await _emailSender.SendEmail(result);
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return null;
            }
            var findUser = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (findUser != null ) {
                if (!findUser.EmailConfirmed)
                {
                    string token = await _userManager.GenerateEmailConfirmationTokenAsync(findUser);
                    await SendEmail(findUser?.Email, token, "active", "ActivateAccount", "Please Active your account , click on link to active");
                    return "Please confirm your email first, we have sent the activation link to your E-mail";
                }

                var result = await _signInManager.CheckPasswordSignInAsync(findUser, loginDTO.Password, true);

                if (result.Succeeded)
                {
                    return generateToken.GetAndCreateToken(findUser);
                }
                return "Wrong email or Passowrd , please try again";
            }
            return "Wrong Email Provided";
            

            

        }

        public async Task<bool> SendEmailForForger(string email)
        {
            var findUser = await _userManager.FindByEmailAsync(email);
            if (findUser is null)
            {
                return false;
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(findUser);
            await SendEmail(findUser?.Email, token, "Reset-password", "Reset Password", "Click on link to reset your password");

            return true;



        }

        public async Task<string> ResetPassword(ResetPassword resetPasswordDto)
        {
            var findUser = await _userManager.FindByEmailAsync(resetPasswordDto.email);
            if (findUser is null)
            {
                return "Email not Found";
            }

            var result = await _userManager.ResetPasswordAsync(findUser,resetPasswordDto.token,resetPasswordDto.password);

            if (result.Succeeded)
            {
                return "Password Changed Successfully";
            }
            return result.Errors.ToList()[0].Description;
        }

        public async Task<bool> ActiveAccount(ActiveAccount activeAccountDto)
        {
            var findUser= await _userManager.FindByEmailAsync(activeAccountDto.Email);
            if (findUser is null)
            {
                return false;
            }

            var result = await _userManager.ConfirmEmailAsync(findUser,activeAccountDto.token);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(findUser);
                await SendEmail(findUser?.Email, token, "active", "ActivateAccount", "Please Active your account , click on link to active");
                return false;
            }
        } 


    }
}
