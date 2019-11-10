using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Attend_list
	/// </summary>
	public partial class Attend_list
	{
		public Attend_list()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StuNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Attend_list");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)			};
			parameters[0].Value = StuNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Attend_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Attend_list(");
			strSql.Append("StuNo,StuName,Teacher_name,CouseName,Attend)");
			strSql.Append(" values (");
			strSql.Append("@StuNo,@StuName,@Teacher_name,@CouseName,@Attend)");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20),
					new SqlParameter("@StuName", SqlDbType.VarChar,30),
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,20),
					new SqlParameter("@CouseName", SqlDbType.VarChar,20),
					new SqlParameter("@Attend", SqlDbType.NChar,2)};
			parameters[0].Value = model.StuNo;
			parameters[1].Value = model.StuName;
			parameters[2].Value = model.Teacher_name;
			parameters[3].Value = model.CouseName;
			parameters[4].Value = model.Attend;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Attend_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Attend_list set ");
			strSql.Append("StuName=@StuName,");
			strSql.Append("Teacher_name=@Teacher_name,");
			strSql.Append("CouseName=@CouseName,");
			strSql.Append("Attend=@Attend");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuName", SqlDbType.VarChar,30),
					new SqlParameter("@Teacher_name", SqlDbType.VarChar,20),
					new SqlParameter("@CouseName", SqlDbType.VarChar,20),
					new SqlParameter("@Attend", SqlDbType.NChar,2),
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)};
			parameters[0].Value = model.StuName;
			parameters[1].Value = model.Teacher_name;
			parameters[2].Value = model.CouseName;
			parameters[3].Value = model.Attend;
			parameters[4].Value = model.StuNo;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StuNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Attend_list ");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)			};
			parameters[0].Value = StuNo;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string StuNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Attend_list ");
			strSql.Append(" where StuNo in ("+StuNolist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Attend_list GetModel(string StuNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StuNo,StuName,Teacher_name,CouseName,Attend from Attend_list ");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)			};
			parameters[0].Value = StuNo;

			Maticsoft.Model.Attend_list model=new Maticsoft.Model.Attend_list();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Attend_list DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Attend_list model=new Maticsoft.Model.Attend_list();
			if (row != null)
			{
				if(row["StuNo"]!=null)
				{
					model.StuNo=row["StuNo"].ToString();
				}
				if(row["StuName"]!=null)
				{
					model.StuName=row["StuName"].ToString();
				}
				if(row["Teacher_name"]!=null)
				{
					model.Teacher_name=row["Teacher_name"].ToString();
				}
				if(row["CouseName"]!=null)
				{
					model.CouseName=row["CouseName"].ToString();
				}
				if(row["Attend"]!=null)
				{
					model.Attend=row["Attend"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StuNo,StuName,Teacher_name,CouseName,Attend ");
			strSql.Append(" FROM Attend_list ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" StuNo,StuName,Teacher_name,CouseName,Attend ");
			strSql.Append(" FROM Attend_list ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Attend_list ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.StuNo desc");
			}
			strSql.Append(")AS Row, T.*  from Attend_list T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Attend_list";
			parameters[1].Value = "StuNo";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

