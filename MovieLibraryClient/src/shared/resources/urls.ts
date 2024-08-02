export enum Urls {
  /* HRT AUTH */
  MOVIE_LIBRARY_SERVER_PROTOCOL = "https",
  MOVIE_LIBRARY_SERVER_HOST = "localhost",
  MOVIE_LIBRARY_SERVER_PORT = "5173",
  MOVIE_LIBRARY_SERVER_SUFFIX = "api"
}
export type UrlsParam = "movie-library-server";

export const getAssociatedUrl = (name: UrlsParam): string => {
  switch (name) {
    case "movie-library-server":
      return `${Urls.MOVIE_LIBRARY_SERVER_PROTOCOL}://${Urls.MOVIE_LIBRARY_SERVER_HOST}:${Urls.MOVIE_LIBRARY_SERVER_PORT}/${Urls.MOVIE_LIBRARY_SERVER_SUFFIX}`;
  }
};
