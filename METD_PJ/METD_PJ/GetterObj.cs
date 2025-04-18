﻿using BK_Functions.Local.Curso;
using BK_Functions.Local.Disciplina;
using BK_Functions.Models;
using CefSharp;
using CefSharp.WinForms;
using METD_PJ.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace METD_PJ
{
    public class GetterObj
    {
        public ChromiumWebBrowser? chromeBrowser;
        ICourseRepository? courseRepository;
        IDisciplineRepository? disciplineRepository;

        public GetterObj(ChromiumWebBrowser chromeBrowser)
        {
            this.chromeBrowser = chromeBrowser;
            courseRepository = new CourseRepository();
            disciplineRepository = new DisciplineRepository();
        }

        public void get_Cursos()
        {
            var lista = courseRepository?.Get();
            var jsonLista = JsonConvert.SerializeObject(lista);

            //preenchendo lista de cursos
            chromeBrowser.EvaluateScriptAsync($"receberLista({jsonLista});");

            //debug
            //chromeBrowser.ShowDevTools();
        }

        public void get_Disciplinas(string content)
        {
            try
            {
                var _id = new Regex(@"\(\d{1,2}\)").Match(content).Value.Replace("(", "").Replace(")", "");

                List<DisciplineModel>? lista = courseRepository?.Get().FirstOrDefault(x => x.Id == int.Parse(_id))?.Disciplines;

                var jsonLista = JsonConvert.SerializeObject(lista);

                //preenchendo lista de disciplinas
                chromeBrowser.EvaluateScriptAsync($"receberListaDisciplinas({jsonLista});");
            }
            catch (Exception)
            {
                chromeBrowser.EvaluateScriptAsync($"limparDisciplinas();");
            }
        }

        public void get_Disciplinas_Curso(string content)
        {
            try
            {
                var _id = new Regex(@"\(\d{1,2}\)").Match(content).Value.Replace("(", "").Replace(")", "");

                List<DisciplineModel>? disciplinas_curso = courseRepository?.Get().FirstOrDefault(x => x.Id == int.Parse(_id))?.Disciplines;
                List<DisciplineModel>? disciplinas_todas = disciplineRepository?.Get();

                if (disciplinas_curso == null) return;
                if (disciplinas_todas == null || disciplinas_todas.Count == 0) return;

                for (int i = 0; i < disciplinas_todas.Count; i++)
                {
                    var disciplina_Existente = disciplinas_curso.FirstOrDefault(x => x.Id == disciplinas_todas[i].Id);

                    if (disciplina_Existente != null)
                    {
                        disciplinas_curso.Remove(disciplina_Existente);
                    }
                    else
                    {
                        disciplinas_curso.Add(disciplinas_todas[i]);
                    }
                }

                var jsonLista = JsonConvert.SerializeObject(disciplinas_curso);
                chromeBrowser.EvaluateScriptAsync($"receberListaDisciplinasAdicionar({jsonLista});");
            }
            catch (Exception)
            {
                chromeBrowser.EvaluateScriptAsync($"limparDisciplinas();");
            }
        }

        public void post_disciplina_curso(string curso, string disciplina)
        {
            if (disciplina.Trim().IsVazio())
            {
                MessageBox.Show("CURSO OU DISCIPLINA INEXISTE");
                return;
            }

            var result = MessageBox.Show($"Adicionar '{disciplina.ToUpper()}' ao curso '{curso.ToUpper()}'?", "SISTEMA", MessageBoxButtons.OKCancel);

            if (result is DialogResult.OK)
            {
                disciplineRepository?.PostDisciplineIntoCourse(disciplina.GetId(), curso.GetId());
                get_Disciplinas(curso);
                get_Disciplinas_Curso(curso);
                MessageBox.Show("Adicionado com sucesso!");
            }
        }

        public void delete_disciplina_curso(string curso, string disciplina)
        {
            if (disciplina.IsVazio())
            {
                return;
            }

            var result = MessageBox.Show($"Remover a '{disciplina.ToUpper()}' do curso '{curso.ToUpper()}'?", "SISTEMA", MessageBoxButtons.OKCancel);
            
            try
            {
                if (result is DialogResult.OK)
                {
                    disciplineRepository?.DeleteDisciplineFromCourse(disciplina.GetId(), curso.GetId());
                    MessageBox.Show("A disciplina foi removida com êxito!");
                }
            }
            catch (Exception){}
            
            get_Disciplinas(curso);
            get_Disciplinas_Curso(curso);
        }

        public void get_Filtro_Geral()
        {
            var lista = new List<string> { "Curso", "Professor", "Sala", "Período", "Data" };
            var jsonLista = JsonConvert.SerializeObject(lista);
            chromeBrowser.EvaluateScriptAsync($"receberFiltroGeral({jsonLista});");
        }


    }
}
