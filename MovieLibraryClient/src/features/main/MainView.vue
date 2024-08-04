<script setup lang="ts">
import HomeHeader from "../../components/headers/HomeHeader.vue";
import HomeLayout from "../../components/layouts/HomeLayout.vue";
import HorizontalMenu from "../../components/menus/HorizontalMenu.vue";
import ProgressSpinner from "primevue/progressspinner";
import { useMainMenu } from "./main-composables/useMainMenu.ts";
import Toast from "primevue/toast";
import { useInterceptorEmitterEvents } from "./main-composables/useInterceptorEmitterEvents.ts";
import { useToast } from "primevue/usetoast";
import { inject } from "vue";
import { TinyEmitter } from "tiny-emitter";
const menuItems = useMainMenu();
const toast = useToast();
const emitter = inject<TinyEmitter>("emitter")!;

const { loadingState } = useInterceptorEmitterEvents(toast, emitter);
</script>

<template>
  <HomeLayout>
    <template #header>
      <HomeHeader>
        <template #menu>
          <HorizontalMenu :items="menuItems" />
        </template>
        <template #corner>
          <div class="w-full h-full flex items-center justify-end">
            <ProgressSpinner
              v-show="loadingState"
              style="width: 50px; height: 50px"
              strokeWidth="3"
              fill="transparent"
              animationDuration=".5s"
              aria-label="Custom ProgressSpinner"
            />
          </div>
        </template>
      </HomeHeader>
    </template>
    <template #body>
      <router-view />
    </template>
    <template #footer>
      <!-- footer -->
    </template>
  </HomeLayout>
  <Toast />
</template>
