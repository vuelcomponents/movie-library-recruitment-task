<script setup lang="ts">
import HomeHeader from "@/components/headers/HomeHeader.vue";
import HomeLayout from "@/components/layouts/HomeLayout.vue";
</script>

<template>
  <HomeLayout>
    <template #header>
      <HomeHeader />
    </template>
    <template #body>
      <router-view />
    </template>
    <template #footer>
     <!-- footer -->
    </template>
  </HomeLayout>
</template>

