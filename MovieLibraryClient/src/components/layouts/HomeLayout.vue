<script setup lang="ts">
</script>

<template>
  <main class="w-screen h-screen">
    <section class="max-h-20 h-20 xl:px-40 md:px-20 px-4">
      <slot name="header"/>
    </section>
    <section class="h-full-minus-20 w-full">
      <slot name="body"/>
    </section>
    <section class="footer">
      <slot name="footer"/>
    </section>
  </main>
</template>
