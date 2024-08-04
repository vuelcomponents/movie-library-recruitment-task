import { between, maxLength, required } from "@vuelidate/validators";

export const useMovieRules = () => {
  const rules = {
    title: { required, maxLength: maxLength(200) },
    year: { required, between: between(1900, 2200) },
    director: { required },
    rate: { required, between: between(0, 10) },
  };
  const errorMessages = {
    title: {
      required: "Title must be provided",
      minLength: "Title must be at least 1 character long",
    },
    year: {
      required: "Year must be provided",
      between: "Year must be between 1900 and 2200",
    },
    director: {
      required: "Director must be provided",
    },
    rate: {
      between: "Rate must be between 0 and 10",
    },
  };
  return {
    rules,
    errorMessages,
  };
};
