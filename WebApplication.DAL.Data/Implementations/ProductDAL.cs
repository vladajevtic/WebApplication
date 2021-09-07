﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApplication.DAL.Data.Entities;
using WebApplication.DAL.Data.Interfaces;

namespace WebApplication.DAL.Data.Implementations
{
    public class ProductDAL : BaseDAL, IProductDAL
    {
        protected override string COLUMN_PREFIX
        {
            get { return ColumnPrefixConstants.PROD; }
        }
        public List<Product> GetAll(int skip, int take)
        {


            SqlConnection cn = ConnectionGet();

            Product result = null;
            List<Product> results = new List<Product>();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_GetAll_Skip_Take";

            this.ParamValueTypeNonNullableValueSet(cmd, skip, "@RowsToSkip", SqlDbType.Int);
            this.ParamValueTypeNonNullableValueSet(cmd, take, "@RowsToTake", SqlDbType.Int);

            try
            {
                cn.Open();

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = Create(reader);
                    results.Add(result);
                }
            }
            catch (Exception ex)
            {
                //DMLogger.Singleton.LogError(LogCategories.SECURITY, ex);
                throw;
            }
            finally
            {
                cn.Close();
            }
            return results;
        }

        public Product GetById(int id)
        {
            SqlConnection cn = ConnectionGet();

            Product result = null;

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_GetById";

            this.ParamValueTypeNonNullableValueSet(cmd, id, "@ProductId", SqlDbType.Int);

            try
            {
                cn.Open();

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = Create(reader);
                }
            }
            catch (Exception ex)
            {
                //DMLogger.Singleton.LogError(LogCategories.SECURITY, ex);
                throw;
            }
            finally
            {
                cn.Close();
            }
            return result;
        }
        private Product Create(IDataReader reader)
        {
            Product item = new Product(ReaderColumnReadNullableValueType<Int32>(reader, "ID", COLUMN_PREFIX));

            item.Name = ReaderColumnReadObject<string>(reader, "ProductName", COLUMN_PREFIX);
            item.Price = ReaderColumnReadValueType<decimal>(reader, "UnitPrice", COLUMN_PREFIX);
            item.IsDiscounted = ReaderColumnReadValueType<bool>(reader, "IsDiscounted", COLUMN_PREFIX);
            item.IsActive = ReaderColumnReadValueType<bool>(reader, "IsActive", COLUMN_PREFIX);
            item.IsDeleted = ReaderColumnReadValueType<bool>(reader, "IsDeleted", COLUMN_PREFIX);

            return item;
        }

        public void Save(Product item)
        {
            switch (item.EntityState)
            {
                case EntityStateEnum.New:
                    this.Add(item);
                    break;
                case EntityStateEnum.Updated:
                    this.Update(item);
                    break;
                case EntityStateEnum.Deleted:
                    this.Delete(item);
                    break;
                case EntityStateEnum.Loaded:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("EntityState is invalid: Value: {0}", item.EntityState));
            }
            item.EntityState = EntityStateEnum.Loaded;
        }

        private void Add(Product item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_Ins";

            CommonParametersAdd(item, cmd);

            SqlParameter prm = new SqlParameter();
            prm.ParameterName = "@ID";
            prm.SqlDbType = SqlDbType.Int;
            prm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prm);

            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();

                item.Id = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            }
            catch (Exception ex)
            {
                //DMLogger.Singleton.LogError(ex, item);
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        private void CommonParametersAdd(Product item, SqlCommand cmd)
        {

            this.ParamStringNonNullableValueSet(cmd, item.Name, "@Name", SqlDbType.NVarChar, 50);
            this.ParamValueTypeNonNullableValueSet(cmd, item.Price, "@UnitPrice", SqlDbType.Decimal);
            this.ParamNullableValueTypeNullableValueSet(cmd, item.IsDiscounted, "@IsDiscounted", SqlDbType.Bit);
            this.ParamValueTypeNonNullableValueSet(cmd, item.IsActive, "@IsActive", SqlDbType.Bit);
            this.ParamValueTypeNonNullableValueSet(cmd, item.IsDeleted, "@IsDeleted", SqlDbType.Bit);
            this.ParamStringNullableValueSet(cmd, item.Size, "@Size", SqlDbType.NVarChar, 50);
        }

        private void Update(Product item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_Upd";

            CommonParametersAdd(item, cmd);

            SqlParameter prm = new SqlParameter();
            prm.ParameterName = "@ID";
            prm.SqlDbType = SqlDbType.Int;
            prm.Value = item.Id.Value;
            cmd.Parameters.Add(prm);

            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //DMLogger.Singleton.LogError(ex, item);
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        private void Delete(Product item)
        {
            SqlConnection cn = ConnectionGet();

            SqlCommand cmd = CommandGet(cn);
            cmd.CommandText = "Product_Del";

            CommonParametersAdd(item, cmd);

            SqlParameter prm = new SqlParameter();
            prm.ParameterName = "@ID";
            prm.SqlDbType = SqlDbType.Int;
            prm.Value = item.Id.Value;
            cmd.Parameters.Add(prm);

            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //DMLogger.Singleton.LogError(ex, item);
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
