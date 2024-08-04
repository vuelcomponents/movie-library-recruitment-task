<script setup lang="ts">
import Rating from "primevue/rating";
import type { ICellRendererParams } from "ag-grid-community";
import { Movie } from "../../../../entities/movie/Movie.ts";
defineProps<{
  params: ICellRendererParams<Movie>;
}>();
</script>

<template>
  <div class="h-full w-full centered cursor-default">
    <Rating v-model="params.data!.rate" :stars="10" />
  </div>
</template>
