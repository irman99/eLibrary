using eLibrary.Commons.DTOs.Requests.Ocjene;
using eLibrary.Commons.DTOs.Responses;


    namespace eLibrary.Commons.Interfaces
    {
        public interface IOcjeneService
        {
            CommonResponse CreateOcjenaKorisnik(CreateOcjenaRequest request);
            CommonResponse CreateOcjenaKnjiga(CreateOcjenaRequest request);
            CommonResponse UpdateOcjena(UpdateOcjenaRequest request);
            GetOcjenaResponse GetOcjenaKorisnika(GetOcjenaRequest request);
            GetOcjenaResponse GetOcjenaKnjige(GetOcjenaRequest request);
    }
    }

