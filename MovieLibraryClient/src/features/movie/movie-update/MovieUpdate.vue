<script setup lang="ts">
import { Movie } from "../../../entities/movie/Movie.ts";
import InputText from "primevue/inputtext";
import InputNumber from "primevue/inputnumber";
import { Identified } from "../../../shared/types/Identified.ts";
import { useMovieRules } from "../movie-composables/useMovieRules.ts";
import { useVuelidate } from "@vuelidate/core";
import Rating from "primevue/rating";
import StandardForm from "../../../components/forms/StandardForm.vue";
const props = defineProps<{
  movie: Identified<Movie>;
}>();
const emit = defineEmits<{
  onMovieUpdateSave: [Identified<Movie>];
}>();

const { rules, errorMessages } = useMovieRules();

const v$ = useVuelidate(rules, props.movie, { $lazy: true });
const handleSave = async () => {
  await v$.value.$validate();
  if (!v$.value.$error) {
    emit("onMovieUpdateSave", props.movie);
  }
};
</script>

<template>
  <StandardForm  @submit="handleSave"
                 :error-messages="errorMessages"
                 :inputs="['title', 'director', 'year', 'rate']"
                 :v$="v$">
    <template #input_title>
      <input-text name="title" v-model="movie.title" placeholder="Title" />
    </template>
    <template #input_director>
      <input-text
          name="director"
          v-model="movie.director"
          placeholder="Director"
      />
    </template>
    <template #input_year>
      <input-number name="year" v-model="movie.year"
                    :useGrouping="false"
                    :max-fraction-digits="0" />
    </template>
    <template #input_rate>
      <Rating name="rate" v-model="movie.rate" :stars="10" />
    </template>
  </StandardForm>
</template>
<!--  <section class="flex flex-col gap-2 w-full">-->
<!--    <div class="flex flex-col gap-1">-->
<!--      <label for="title" class="text-sm">Title</label>-->
<!--      <input-text-->
<!--        name="title"-->
<!--        v-model="props.movie.title"-->
<!--        placeholder="Title"-->
<!--      />-->
<!--      <div v-for="error of v$.title.$errors" :key="error.$uid">-->
<!--        <div class="error-msg text-sm text-movieTheme-200">-->
<!--          {{ (errorMessages.title as any)[error.$validator] || error.$message }}-->
<!--        </div>-->
<!--      </div>-->
<!--    </div>-->
<!--    <div class="flex flex-col gap-1">-->
<!--      <label for="director" class="text-sm">Director</label>-->
<!--      <input-text-->
<!--        name="director"-->
<!--        v-model="props.movie.director"-->
<!--        placeholder="Director"-->
<!--      />-->
<!--      <div v-for="error of v$.director.$errors" :key="error.$uid">-->
<!--        <div class="text-sm text-movieTheme-200">-->
<!--          {{-->
<!--            (errorMessages.director as any)[error.$validator] || error.$message-->
<!--          }}-->
<!--        </div>-->
<!--      </div>-->
<!--    </div>-->
<!--    <div class="flex flex-col gap-1">-->
<!--      <label for="year" class="text-sm">Year</label>-->
<!--      <input-number name="year" v-model="props.movie.year" />-->
<!--      <div v-for="error of v$.year.$errors" :key="error.$uid">-->
<!--        <div class="text-sm text-movieTheme-200">-->
<!--          {{ (errorMessages.year as any)[error.$validator] || error.$message }}-->
<!--        </div>-->
<!--      </div>-->
<!--    </div>-->
<!--    <div class="my-2 flex flex-col gap-1">-->
<!--      <label for="rate" class="text-sm">Rate</label>-->
<!--      <Rating name="rate" v-model="props.movie.rate" :stars="10" />-->
<!--      <div v-for="error of v$.rate.$errors" :key="error.$uid">-->
<!--        <div class="text-sm text-movieTheme-200">-->
<!--          (errorMessages.rate as any)[error.$validator] || error.$message-->
<!--        </div>-->
<!--      </div>-->
<!--    </div>-->
<!--    <Button @click="handleSave">Save</Button>-->
<!--  </section>-->