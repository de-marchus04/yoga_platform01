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
        private Dictionary<string, List<RetreatDto>> _activeRetreatsCache = new();
        private Dictionary<string, List<RetreatDto>> _upcomingRetreatsCache = new();
        private Dictionary<string, List<RetreatDto>> _pastRetreatsCache = new();
        private Dictionary<string, List<YagyaDto>> _activeYagyasCache = new();
        private Dictionary<string, List<YagyaDto>> _upcomingYagyasCache = new();
        private Dictionary<string, List<YagyaDto>> _pastYagyasCache = new();

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
        
        public async Task<List<RetreatDto>> GetActiveRetreatsAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_activeRetreatsCache.ContainsKey(lang))
            {
                _activeRetreatsCache[lang] = await _api.GetActiveRetreatsAsync(lang);
            }
            return _activeRetreatsCache[lang];
        }

        public async Task<List<RetreatDto>> GetUpcomingRetreatsAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_upcomingRetreatsCache.ContainsKey(lang))
            {
                _upcomingRetreatsCache[lang] = await _api.GetUpcomingRetreatsAsync(lang);
            }
            return _upcomingRetreatsCache[lang];
        }

        public async Task<List<RetreatDto>> GetPastRetreatsAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_pastRetreatsCache.ContainsKey(lang))
            {
                _pastRetreatsCache[lang] = await _api.GetPastRetreatsAsync(lang);
            }
            return _pastRetreatsCache[lang];
        }

        public async Task<List<YagyaDto>> GetActiveYagyasAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_activeYagyasCache.ContainsKey(lang))
            {
                _activeYagyasCache[lang] = await _api.GetActiveYagyasAsync(lang);
            }

            return _activeYagyasCache[lang];
        }

        public async Task<List<YagyaDto>> GetUpcomingYagyasAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_upcomingYagyasCache.ContainsKey(lang))
            {
                _upcomingYagyasCache[lang] = await _api.GetUpcomingYagyasAsync(lang);
            }

            return _upcomingYagyasCache[lang];
        }

        public async Task<List<YagyaDto>> GetPastYagyasAsync(string lang, bool forceRefresh = false)
        {
            if (forceRefresh || !_pastYagyasCache.ContainsKey(lang))
            {
                _pastYagyasCache[lang] = await _api.GetPastYagyasAsync(lang);
            }

            return _pastYagyasCache[lang];
        }

        public void ClearCache()
        {
            _coursesCache.Clear();
            _consultationsCache.Clear();
            _activeRetreatsCache.Clear();
            _upcomingRetreatsCache.Clear();
            _pastRetreatsCache.Clear();
            _activeYagyasCache.Clear();
            _upcomingYagyasCache.Clear();
            _pastYagyasCache.Clear();
        }
        
        public void ClearCacheForLang(string lang)
        {
            _coursesCache.Remove(lang);
            _consultationsCache.Remove(lang);
            _activeRetreatsCache.Remove(lang);
            _upcomingRetreatsCache.Remove(lang);
            _pastRetreatsCache.Remove(lang);
            _activeYagyasCache.Remove(lang);
            _upcomingYagyasCache.Remove(lang);
            _pastYagyasCache.Remove(lang);
        }
    }
}
