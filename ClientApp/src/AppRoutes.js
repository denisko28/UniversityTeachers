import { DisciplinesDataView } from "./views/DisciplinesDataView";
import { HomeAddressesDataView } from "./views/HomeAddressesDataView";
import { StreetsDataView } from "./views/StreetsDataView";
import { TeachersDataView } from "./views/TeachersDataView";
import { PositionsDataView } from "./views/PositionsDataView"
import { WorkPlacesDataView } from "./views/WorkPlacesDataView";

const AppRoutes = [
  {
    index: true,
    element: <TeachersDataView />
  },
  {
    path: '/positions-data',
    element: <PositionsDataView />
  },
  {
    path: '/disciplines-data',
    element: <DisciplinesDataView />
  },
  {
    path: '/workPlaces-data',
    element: <WorkPlacesDataView />
  },
  {
    path: '/homeAddresses-data',
    element: <HomeAddressesDataView />
  },
  {
    path: '/streets-data',
    element: <StreetsDataView />
  }
];

export default AppRoutes;
