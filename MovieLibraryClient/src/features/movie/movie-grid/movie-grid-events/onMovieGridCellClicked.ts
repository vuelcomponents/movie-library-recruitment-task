import { CellClickedEvent } from "ag-grid-community";
import { Movie } from "../../../../entities/movie/Movie.ts";
import { Actionable } from "../../../../shared/grid/grid-types/Actionable.ts";
import { Service } from "../../../../shared/services/Service.ts";
import { AxiosResponse } from "axios";

export const onMovieGridCellClicked = (
  event: CellClickedEvent<Actionable<Movie>>,
  service: Service<Movie>,
  emit: any,
) => {
  switch (event.colDef.field) {
    case "remove":
      service.deleteMany([event.data]).then((result: AxiosResponse) => {
        if (result.status === 200) {
          event.api.applyTransaction({ remove: [event.data!] });
        }
      });
      break;
    case "edit":
      emit("updateMovie", event.data);
      break;
  }
};
