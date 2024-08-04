<script setup lang="ts">
import bg from '@/assets/bg5.jpg';
</script>
<template>
  <section class="xl:px-40 md:px-20 px-4 py-2" :style="`background:url('${bg}')`">
    <slot/>
  </section>
</template>
