using System.Collections.Generic;
using Logic;

namespace DataAccess {
    public interface IHouseRepository : IBaseRepository {
        House GetHouse(int houseId);
        IEnumerable<House> Houses { get; }
    }
}
