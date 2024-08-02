<script setup lang="ts">
import Rating from 'primevue/rating';
import type { ICellRendererParams } from 'ag-grid-community';
import {Movie} from "../../../../entities/movie/Movie.ts";
const props = defineProps<{
  params:ICellRendererParams<Movie>
}>()
</script>

<template>
<Rating v-model="params.data.rate" :stars="10"/>
</template>
