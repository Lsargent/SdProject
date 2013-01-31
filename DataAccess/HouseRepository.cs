using System.Collections.Generic;
using Logic;

namespace DataAccess {
    class HouseRepository : RepositoryBase<SdDb>, IHouseRepository {
        private IEnumerable<House> _houses;
        public IEnumerable<House> Houses {
            get { return _houses ?? (_houses = GetAll<House>()); }
        } 

        public House GetHouse(int houseId) {
            return Get<House>( house => house.Id == houseId);
        }
    }
}
