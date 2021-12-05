using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tools
{
    public class RequestSender
    {
        private static HttpClient _client;

        /// <summary>
        /// /Destruye el objeto HttpClient
        /// </summary>
        public static void destroy()
        {
            if (_client != null)
                _client = null;
        }

        public RequestSender(string baseURI)
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(baseURI);
            }
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));
        }

        public RequestSender(string baseURI, string Token)
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(baseURI);
                _client.DefaultRequestHeaders.Accept.Clear();
            }

            if (_client.DefaultRequestHeaders.Authorization == null)
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));
        }
        /// <summary>
        /// Se obtiene el resultado del método GET.
        /// </summary>
        /// <param name="path">La ruta o cade que contiene los arributo</param>
        /// <returns></returns>
        public async Task<dynamic> Get(string path)
        {
            var response = await _client.GetStreamAsync(path);
            return response;
        }

        public async Task<List<T>> Get1<T>(string path)
        {
            var response = await _client.GetStreamAsync(path);
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return await JsonSerializer.DeserializeAsync<List<T>>(response, options);
        }

        /// <summary>
        /// Obtiene el resultado del método GET.
        /// </summary>
        /// <typeparam name="T">El tipo de objeto que se va devolver</typeparam>
        /// <param name="path">La ruta o cade que contiene los arributo</param>
        /// <returns></returns>
        public async Task<dtoResult<T>> GetList<T>(string path)
        {
            dtoResult<T> odtoResult = new dtoResult<T>();

            try
            {
                if (String.IsNullOrEmpty(path))
                    throw new Exception("El valor del context del api no puede ser vacio o null.");

                var response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode == true)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    odtoResult.Estatus = true;
                    odtoResult.message = "Operación exitosa..";
                    odtoResult.result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(res);
                }
                else
                    throw new Exception(await getMessageException(response));

                return odtoResult;
            }
            catch (Exception ex)
            {
                odtoResult.Estatus = false;
                if (ex.InnerException == null || ex.InnerException.Equals(String.Empty))
                    odtoResult.message = ex.Message;
                else
                    odtoResult.message = ex.InnerException.Message;

                return odtoResult;
            }
        }

        /// <summary>
        /// Obtiene solo un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<dtoResult<T>> Get<T>(string path)
        {
            dtoResult<T> odtoResult = new dtoResult<T>();

            try
            {
                if (String.IsNullOrEmpty(path))
                    throw new Exception("El valor del context del api no puede ser vacio o null.");

                var response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode == true)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    odtoResult.Estatus = true;
                    odtoResult.message = "Operación exitosa..";
                    odtoResult.valor = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);
                }
                else
                    throw new Exception(await getMessageException(response));

                return odtoResult;
            }
            catch (Exception ex)
            {
                odtoResult.Estatus = false;
                if (ex.InnerException == null || ex.InnerException.Equals(String.Empty))
                    odtoResult.message = ex.Message;
                else
                    odtoResult.message = ex.InnerException.Message;

                return odtoResult;
            }
        }



        /// <summary>
        /// Obtiene el resultado del método POST.
        /// </summary>
        /// <typeparam name="T">El tipo de objeto que se va devolver.</typeparam>
        /// <param name="path">La ruta del método de la API.</param>
        /// <param name="content">Los atributos que se van modificar. </param>
        /// <returns></returns>
        public async Task<dtoResult<T>> Post<T>(string path, object content)
        {
            dtoResult<T> odtoResult = new dtoResult<T>();

            try
            {
                if (String.IsNullOrEmpty(path))
                    throw new Exception("El valor del context del api no puede ser vacio o null.");

                StringContent postContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(path, postContent);

                if (response.IsSuccessStatusCode == true)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    odtoResult.Estatus = true;
                    odtoResult.message = "Operación exitosa..";
                    odtoResult.valor = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                    throw new Exception(await getMessageException(response));

                return odtoResult;
            }
            catch (Exception ex)
            {
                odtoResult.Estatus = false;
                if (ex.InnerException == null || ex.InnerException.Equals(String.Empty))
                    odtoResult.message = ex.Message;
                else
                    odtoResult.message = ex.InnerException.Message;

                return odtoResult;
            }
        }

        /// <summary>
        /// Metodo para modificar recursos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<dtoResult<T>> Put<T>(string path, object content)
        {
            dtoResult<T> odtoResult = new dtoResult<T>();

            try
            {
                if (String.IsNullOrEmpty(path))
                    throw new Exception("El valor del context del api no puede ser vacio o null.");

                StringContent postContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");

                var response = await _client.PutAsync(path, postContent);

                if (response.IsSuccessStatusCode == true)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    odtoResult.Estatus = true;
                    odtoResult.message = "Operación exitosa..";
                    odtoResult.valor = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                    throw new Exception(await getMessageException(response));

                return odtoResult;
            }
            catch (Exception ex)
            {
                odtoResult.Estatus = false;
                if (ex.InnerException == null || ex.InnerException.Equals(String.Empty))
                    odtoResult.message = ex.Message;
                else
                    odtoResult.message = ex.InnerException.Message;

                return odtoResult;
            }
        }

        /// <summary>
        /// Obtiene el resultado del método DELETE.
        /// </summary>
        /// <typeparam name="T">El tipo de objeto que se va devolver</typeparam>
        /// <param name="path">La ruta o cade que contiene los arributo</param>
        /// <returns></returns>
        public async Task<dtoResult<T>> Delet<T>(string path)
        {
            dtoResult<T> odtoResult = new dtoResult<T>();

            try
            {
                if (String.IsNullOrEmpty(path))
                    throw new Exception("El valor del context del api no puede ser vacio o null.");

                var response = await _client.DeleteAsync(path);

                if (response.IsSuccessStatusCode == true)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    odtoResult.Estatus = true;
                    odtoResult.message = "Operación exitosa..";
                    odtoResult.valor = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                    throw new Exception(await getMessageException(response));

                return odtoResult;
            }
            catch (Exception ex)
            {
                odtoResult.Estatus = false;
                if (ex.InnerException == null || ex.InnerException.Equals(String.Empty))
                    odtoResult.message = ex.Message;
                else
                    odtoResult.message = ex.InnerException.Message;

                return odtoResult;
            }
        }

        public async Task<String> getMessageException(HttpResponseMessage response)
        {
            try
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ProblemDetails problem = Newtonsoft.Json.JsonConvert.DeserializeObject<ProblemDetails>(responseContent);
                return problem.Title;
            }
            catch
            {
                return "StatusCode= " + response.StatusCode + " ReasonPhrase= " + response.ReasonPhrase;
            }

        }
    }

    public class dtoResult<T>
    {
        public Boolean Estatus { get; set; }
        public String message { get; set; }

        public List<T> result { get; set; }

        public T valor { get; set; }
    }
}