using System.Collections.Generic;
using System.Threading.Tasks;
using Yoga.Shared.DTOs;

namespace Yoga.Client.Services
{
    public class CatalogStateService
    {
        private readonly ApiService _api;

        private Dictionary<string, List<CourseDto>> _coursesCache = new();
        private Dictionary<string, List<ConsultationDto>> _consultationsCache = new();

        public CatalogStateService(ApiService api)
        {
            _api = api;
        }

        public async Task<List<CourseDto>> GetCoursesAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_coursesCache.ContainsKey(lang))
            {
                _coursesCache[lang] = await _api.GetCoursesAsync(lang);
            }
            return _coursesCache[lang];
        }

        public async Task<List<ConsultationDto>> GetConsultationsAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_consultationsCache.ContainsKey(lang))
            {
                _consultationsCache[lang] = await _api.GetConsultationsAsync(lang);
            }
            return _consultationsCache[lang];
        }

        public void ClearCache()
        {
            _coursesCache.Clear();
            _consultationsCache.Clear();
        }

        public void ClearCacheForLang(string lang)
        {
            _coursesCache.Remove(lang);
            _consultationsCache.Remove(lang);
        }
    }
}
