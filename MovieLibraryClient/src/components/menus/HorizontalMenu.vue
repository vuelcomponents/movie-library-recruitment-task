<script setup lang="ts">
import {HorizontalMenuItem} from "../../features/main/main-composables/useMainMenu.ts";

const props = defineProps<{
  items:HorizontalMenuItem[];
}>();
</script>

<template>
  <menu class="flex gap-2 text-sm text-surface-200">
    <div v-for="item in items">
      <span :class="{'text-movieTheme-0':item.main}">{{item.label}}</span>
    </div>
  </menu>
</template>