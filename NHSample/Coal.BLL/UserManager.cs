using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.Entity;
using System.Data.SqlClient;
using Coal.Util;
using Coal.ViewModel;
using Coal.DAL;

namespace Coal.BLL
{
    public class UserManager
    {
        public static bool AddUser(string email, string nickName, string password, out int userId)
        {
            try
            {
                UsersEntity user = new UsersEntity();
                user.Email = email;
                user.NickName = nickName;
                user.Password = password;
                user.ValidStatus = 0;
                user.GroupId = (int)UserGroup.NewUser;
                user.CreateDate = DateTime.Now;
                UsersEntity.UsersDAO userDao = new UsersEntity.UsersDAO();
                userDao.Add(user, out userId);
                return true;
            }
            catch(Exception ex)
            {
                LogUtility.WriteErrLog(ex);
                userId = -1;
                return false;
            }
        }

        public static bool ValidLogin(string email, string password)
        {
            string name = string.Empty;
            int userId = 0;
            return ValidLogin(email, password, ref name, ref userId);
        }

        public static bool ValidLogin(string email, string password, ref string nickName, ref int userId)
        {
            UsersEntity.UsersDAO userDao = new UsersEntity.UsersDAO();
            string sql = "email = @email and password = @password";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("email", email));
            parameters.Add(new SqlParameter("password", password));
            List<UsersEntity> users = userDao.Find(sql, parameters.ToArray());

            if (users!= null && users.Count == 1)
            {
                nickName = users[0].NickName;
                userId = users[0].ID.Value;
                return true;
            }
            else
            {
                return false;  
            }
        }

        public static bool AddOrUpdateInfo(UserInfoModel userInfoModel)
        {
            try
            {
                UserInfoEntity userInfo;
                UserInfoEntity.UserInfoDAO userDao = new UserInfoEntity.UserInfoDAO();

                if (userInfoModel.ID > 0)
                {
                    userInfo = userDao.FindById(userInfoModel.ID);
                    userInfo.BizEmail = userInfoModel.BizEmail;
                    //userInfo.CorpName;
                    userInfo.Fax = userInfoModel.Fax;
                    userInfo.FixedTel = userInfoModel.FixedTel;
                    userInfo.MobileTel = userInfoModel.MobileTel;
                    userInfo.Occupation = userInfoModel.Occupation;
                    userInfo.TrueName = userInfoModel.TrueName;
                    userDao.Update(userInfo);
                }
                else
                {
                    userInfo = new UserInfoEntity();
                    userInfo.BizEmail = userInfoModel.BizEmail;
                    //userInfo.CorpName;
                    userInfo.Fax = userInfoModel.Fax;
                    userInfo.FixedTel = userInfoModel.FixedTel;
                    userInfo.MobileTel = userInfoModel.MobileTel;
                    userInfo.Occupation = userInfoModel.Occupation;
                    userInfo.TrueName = userInfoModel.TrueName;
                    userDao.Add(userInfo);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogUtility.WriteErrLog(ex);
                return false;
            }
        }

        public static void GetUserInfo(int userId,UserInfoModel model)
        {
            UserInfoEntity.UserInfoDAO userDao = new UserInfoEntity.UserInfoDAO();
            List<UserInfoEntity> entitys 
                = userDao.Find("UserId=@user_id",
                                new SqlParameter[]{new SqlParameter("user_id",userId)});

            if (entitys != null && entitys.Count == 1)
            {
                model.BizEmail = entitys[0].BizEmail;
                //userInfo.CorpName;
                model.Fax = entitys[0].Fax;
                model.FixedTel = entitys[0].FixedTel;
                model.MobileTel = entitys[0].MobileTel;
                model.Occupation = entitys[0].Occupation;
                model.TrueName = entitys[0].TrueName;
                model.ID = entitys[0].ID.Value;
            }
        }

        public static bool AddOrUpdateCorpInfo(CompanyInfoModel corpModel)
        {
            try
            {
                CompanyInfoEntity corpInfo;
                CompanyInfoEntity.CompanyInfoDAO corpInfoDao = new CompanyInfoEntity.CompanyInfoDAO();

                if (corpModel.ID > 0)
                {
                    corpInfo = corpInfoDao.FindById(corpModel.ID);
                    corpInfo.Address = corpModel.Address;
                    corpInfo.BusinessScope = corpModel.BusinessScope;
                    corpInfo.CompanyName = corpModel.CompanyName;
                    corpInfo.CompanyType = corpModel.CompanyType;
                    corpInfo.EstablishDate = corpModel.EstablishDate;
                    corpInfo.Introduction = corpModel.Introduction;
                    corpInfo.LegalPerson = corpModel.LegalPerson;
                    corpInfo.OperateType = corpModel.OperateType;
                    corpInfo.RegisteredCapital = corpModel.RegisteredCapital;
                    corpInfo.UserId = corpModel.UserId;
                    corpInfo.ZipCode = corpModel.ZipCode;
                    corpInfo.Province = corpModel.Province;
                    corpInfo.City = corpModel.City;
                    corpInfoDao.Update(corpInfo);
                }
                else
                {
                    corpInfo = new CompanyInfoEntity();
                    corpInfo.Address = corpModel.Address;
                    corpInfo.BusinessScope = corpModel.BusinessScope;
                    corpInfo.CompanyName = corpModel.CompanyName;
                    corpInfo.CompanyType = corpModel.CompanyType;
                    corpInfo.EstablishDate = corpModel.EstablishDate;
                    corpInfo.Introduction = corpModel.Introduction;
                    corpInfo.LegalPerson = corpModel.LegalPerson;
                    corpInfo.OperateType = corpModel.OperateType;
                    corpInfo.RegisteredCapital = corpModel.RegisteredCapital;
                    corpInfo.UserId = corpModel.UserId;
                    corpInfo.ZipCode = corpModel.ZipCode;
                    corpInfo.Province = corpModel.Province;
                    corpInfo.City = corpModel.City;
                    corpInfoDao.Add(corpInfo);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogUtility.WriteErrLog(ex);
                return false;
            }
        }

        public static void GetCorpInfo(int userId, CompanyInfoModel model)
        {
            CompanyInfoEntity.CompanyInfoDAO userDao = new CompanyInfoEntity.CompanyInfoDAO();
            List<CompanyInfoEntity> entitys
                = userDao.Find("UserId=@user_id",
                                new SqlParameter[] { new SqlParameter("user_id", userId) });

            if (entitys != null && entitys.Count == 1)
            {
                model.Address = entitys[0].Address;
                model.BusinessScope = entitys[0].BusinessScope;
                model.CompanyName = entitys[0].CompanyName;
                model.CompanyType = entitys[0].CompanyType.Value;
                model.EstablishDate = entitys[0].EstablishDate.Value;
                model.Introduction = entitys[0].Introduction;
                model.LegalPerson = entitys[0].LegalPerson;
                model.OperateType = entitys[0].OperateType.Value;
                model.RegisteredCapital = entitys[0].RegisteredCapital.Value;
                if (entitys[0].City.HasValue)
                {
                    model.City = entitys[0].City.Value;
                }
                if (entitys[0].Province.HasValue)
                {
                    model.Province = entitys[0].Province.Value;
                }
                model.ID = entitys[0].ID.Value;
            }
        }

        public static bool AddOrUpdataCoalTransInfo(CoalTransModel Model)
        {
            try
            {
                CoalTransEntity CoalTransInfo;
                CoalTransEntity.CoalTransDAO CoalTransInfoDao = new CoalTransEntity.CoalTransDAO();

                if (Model.ID > 0)
                {
                    CoalTransInfo = CoalTransInfoDao.FindById(Model.ID);
                    CoalTransInfo.Title = Model.Title;
                    CoalTransInfo.Details = Model.Details;
                    CoalTransInfo.Price = Model.Price;
                    CoalTransInfo.UserId = Model.UserId;
                    CoalTransInfo.County = Model.County;
                    CoalTransInfo.CountyName = Model.CountyName;
                    CoalTransInfo.Province = Model.Province;
                    CoalTransInfo.ProvinceName = Model.ProvinceName;
                    CoalTransInfo.City = Model.City;
                    CoalTransInfo.CityName = Model.CityName;
                    CoalTransInfo.ZipCode = Model.ZipCode;
                    CoalTransInfo.CoalType = Model.CoalType;
                    CoalTransInfo.CoalTypeName = Model.CoalTypeName;
                    CoalTransInfo.Category = Model.Category;
                    CoalTransInfo.CategoryName = Model.CategoryName;
                    CoalTransInfo.CreatedOn = Model.CreatedOn;
                    CoalTransInfo.ValidDate = Model.ValidDate;
                    CoalTransInfo.WholesaleDes = Model.WholesaleDes;
                    CoalTransInfo.ShipDes = Model.ShipDes;
                    CoalTransInfo.Volatility = Model.Volatility;
                    CoalTransInfo.GrainSize = Model.GrainSize;
                    CoalTransInfo.GrainSizeDes = Model.GrainSizeDes;
                    CoalTransInfo.AshContent = Model.AshContent;
                    CoalTransInfo.SurfurContent = Model.SurfurContent;
                    CoalTransInfo.WaterContent = Model.WaterContent;
                    CoalTransInfo.CalorificPower = Model.CalorificPower;
                    CoalTransInfo.TransType = Model.TransType;
                    CoalTransInfoDao.Update(CoalTransInfo);
                }
                else
                {
                    CoalTransInfo = new CoalTransEntity();
                    CoalTransInfo.Title = Model.Title;
                    CoalTransInfo.Details = Model.Details;
                    CoalTransInfo.Price = Model.Price;
                    CoalTransInfo.UserId = Model.UserId;
                    CoalTransInfo.County = Model.County;
                    CoalTransInfo.CountyName = Model.CountyName;
                    CoalTransInfo.Province = Model.Province;
                    CoalTransInfo.ProvinceName = Model.ProvinceName;
                    CoalTransInfo.City = Model.City;
                    CoalTransInfo.CityName = Model.CityName;
                    CoalTransInfo.ZipCode = Model.ZipCode;
                    CoalTransInfo.CoalType = Model.CoalType;
                    CoalTransInfo.CoalTypeName = Model.CoalTypeName;
                    CoalTransInfo.Category = Model.Category;
                    CoalTransInfo.CategoryName = Model.CategoryName;
                    CoalTransInfo.CreatedOn = Model.CreatedOn;
                    CoalTransInfo.ValidDate = Model.ValidDate;
                    CoalTransInfo.WholesaleDes = Model.WholesaleDes;
                    CoalTransInfo.ShipDes = Model.ShipDes;
                    CoalTransInfo.Volatility = Model.Volatility;
                    CoalTransInfo.GrainSize = Model.GrainSize;
                    CoalTransInfo.GrainSizeDes = Model.GrainSizeDes;
                    CoalTransInfo.AshContent = Model.AshContent;
                    CoalTransInfo.SurfurContent = Model.SurfurContent;
                    CoalTransInfo.WaterContent = Model.WaterContent;
                    CoalTransInfo.CalorificPower = Model.CalorificPower;
                    CoalTransInfo.TransType = Model.TransType;
                    CoalTransInfoDao.Update(CoalTransInfo);
                    CoalTransInfoDao.Add(CoalTransInfo);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.WriteErrLog(ex);
                return false;
            }
        }

        public static bool AddDemandInfo(DemandInfoEntity Model)
        {
            DemandInfoEntity.DemandInfoDAO Dao = new DemandInfoEntity.DemandInfoDAO();
            try
            {
                Dao.Add(Model);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
