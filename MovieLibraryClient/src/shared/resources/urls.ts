export enum Urls {
  /* HRT AUTH */
  MOVIE_LIBRARY_SERVER_PROTOCOL = "http",
  MOVIE_LIBRARY_SERVER_HOST = "192.168.1.77",
  MOVIE_LIBRARY_SERVER_PORT = "1910",
}
export type UrlsParam = "movie-library-server";

export const getAssociatedUrl = (name: UrlsParam): string => {
  switch (name) {
    case "movie-library-server":
      return `${Urls.MOVIE_LIBRARY_SERVER_PROTOCOL}://${Urls.MOVIE_LIBRARY_SERVER_HOST}:${Urls.MOVIE_LIBRARY_SERVER_PORT}`;
  }
};
