<script setup lang="ts">
defineProps<{
  icon:string;
  text:string;
}>()
</script>

<template>
<span>
  <i class="mr-2" :class="icon"/>
</span>
<span class="sm:block hidden">
  {{text}}
</span>
</template>