﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidades;
using System.Data;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class accesoDatosSolicitud
    {
        SqlConnection cnx;
        Solicitud s = new Solicitud();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Solicitud> listaSolicitud = null;

        public int insertarSolcitud(Solicitud so)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Solicit", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idsolicitud", "");
                cm.Parameters.AddWithValue("@aula", so.aula);
                cm.Parameters.AddWithValue("@nivel", so.nivel);
                cm.Parameters.AddWithValue("@fechasolicitud", so.fechasolicitud);
                cm.Parameters.AddWithValue("@fechauso", so.fechauso);
                cm.Parameters.AddWithValue("@horainicio", so.horainicio);
                cm.Parameters.AddWithValue("@horafinal", so.horafinal);
                cm.Parameters.AddWithValue("@carrera", so.carrera);
                cm.Parameters.AddWithValue("@asignatura", so.asignatura);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }

        public List<Solicitud> listarSolicitud()
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Solicit", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idsolicitud", "");
                cm.Parameters.AddWithValue("@aula", "");
                cm.Parameters.AddWithValue("@nivel", "");
                cm.Parameters.AddWithValue("@fechasolicitud", "");
                cm.Parameters.AddWithValue("@fechauso", "");
                cm.Parameters.AddWithValue("@horainicio", "");
                cm.Parameters.AddWithValue("@horafinal", "");
                cm.Parameters.AddWithValue("@carrera", "");
                cm.Parameters.AddWithValue("@asignatura", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaSolicitud = new List<Solicitud>();

                while (dr.Read())
                {
                    Solicitud s = new Solicitud();
                    s.idsolicitud = Convert.ToInt32(dr["idsolicitud"].ToString());
                    s.aula = dr["aula"].ToString();
                    s.nivel = dr["nivel"].ToString();
                    s.fechasolicitud = Convert.ToDateTime(dr["fechasolicitud"].ToString());
                    s.fechauso = Convert.ToDateTime (dr["fechauso"].ToString());
                    s.horainicio = Convert.ToDateTime(dr["horainicio"].ToString());
                    s.horafinal = Convert.ToDateTime(dr["horafinal"].ToString());
                    s.carrera = dr["carrera"].ToString();
                    s.asignatura = dr["asignatura"].ToString();
                    listaSolicitud.Add(s);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaSolicitud = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaSolicitud;
        }
        public int eliminarSolicitud(int idsolicit)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Solicit", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idsolicitud", idsolicit);
                cm.Parameters.AddWithValue("@aula", "");
                cm.Parameters.AddWithValue("@nivel", "");
                cm.Parameters.AddWithValue("@fechasolicitud", "");
                cm.Parameters.AddWithValue("@fechauso", "");
                cm.Parameters.AddWithValue("@horainicio", "");
                cm.Parameters.AddWithValue("@horafinal", "");
                cm.Parameters.AddWithValue("@carrera", "");
                cm.Parameters.AddWithValue("@asignatura", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }

        public int EditarSolicitud(Solicitud so)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Solicit", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idsolicitud", so.idsolicitud);
                cm.Parameters.AddWithValue("@aula", "");
                cm.Parameters.AddWithValue("@nivel", "");
                cm.Parameters.AddWithValue("@fechasolicitud", "");
                cm.Parameters.AddWithValue("@fechauso", "");
                cm.Parameters.AddWithValue("@horainicio", "");
                cm.Parameters.AddWithValue("@horafinal", "");
                cm.Parameters.AddWithValue("@carrera", "");
                cm.Parameters.AddWithValue("@asignatura", so.asignatura);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public List<Solicitud> BuscarSolicitud(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Solicit", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idsolicitud", "");
                cm.Parameters.AddWithValue("@aula", dato);
                cm.Parameters.AddWithValue("@nivel", "");
                cm.Parameters.AddWithValue("@fechasolicitud", "");
                cm.Parameters.AddWithValue("@fechauso", "");
                cm.Parameters.AddWithValue("@horainicio", "");
                cm.Parameters.AddWithValue("@horafinal", "");
                cm.Parameters.AddWithValue("@carrera", "");
                cm.Parameters.AddWithValue("@asignatura", dato);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaSolicitud = new List<Solicitud>();

                while (dr.Read())
                {
                    Solicitud s = new Solicitud();
                    s.idsolicitud = Convert.ToInt32(dr["idsolicitud"].ToString());
                    s.aula = dr["aula"].ToString();
                    s.nivel = dr["nivel"].ToString();
                    s.fechasolicitud = Convert.ToDateTime(dr["fechasolicitud"].ToString());
                    s.fechauso = Convert.ToDateTime(dr["fechauso"].ToString());
                    s.horainicio = Convert.ToDateTime(dr["horainicio"].ToString());
                    s.horafinal = Convert.ToDateTime(dr["horafinal"].ToString());
                    s.carrera = dr["carrera"].ToString();
                    s.asignatura = dr["asignatura"].ToString();
                    listaSolicitud.Add(s);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaSolicitud = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaSolicitud;
        }
    }
}