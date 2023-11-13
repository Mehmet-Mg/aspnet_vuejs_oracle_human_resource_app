<template>
      <a-layout style="min-height: 100vh">
            <a-layout-sider v-model:collapsed="collapsed" collapsible>
                  <div class="logo" />
                  <a-menu v-model:selectedKeys="selectedKeys" theme="dark" mode="inline">
                        <a-menu-item key="home" :onclick="() => router.push('/')">
                              <pie-chart-outlined />
                              <span>Home</span>
                        </a-menu-item>
                        <a-menu-item key="employees" :onclick="() => router.push('/employees')">
                              <desktop-outlined />
                              <span>Employees</span>
                        </a-menu-item>
                        <a-menu-item key="departments" :onclick="() => router.push('/departments')">
                              <desktop-outlined />
                              <span>Departments</span>
                        </a-menu-item>
                        <a-menu-item key="jobs" :onclick="() => router.push('/jobs')">
                              <desktop-outlined />
                              <span>Jobs</span>
                        </a-menu-item>
                        <a-menu-item key="countries" :onclick="() => router.push('/countries')">
                              <desktop-outlined />
                              <span>Countries</span>
                        </a-menu-item>
                        <a-menu-item key="regions" :onclick="() => router.push('/regions')">
                              <desktop-outlined />
                              <span>Regions</span>
                        </a-menu-item>
                        <a-menu-item key="locations" :onclick="() => router.push('/locations')">
                              <desktop-outlined />
                              <span>Locations</span>
                        </a-menu-item>
                        <a-menu-item key="8" :onclick="() => router.push('/')">
                              <file-outlined />
                              <span>Job History</span>
                        </a-menu-item>
                  </a-menu>
            </a-layout-sider>
            <a-layout>
                  <a-layout-header style="background: #fff; padding: 0">
                        Human Resource App
                  </a-layout-header>
                  <a-layout-content style="margin: 0 16px">
                        <a-breadcrumb style="margin: 16px 0">
                              <a-breadcrumb-item>User</a-breadcrumb-item>
                              <a-breadcrumb-item>Bill</a-breadcrumb-item>
                        </a-breadcrumb>
                        <div :style="{ padding: '24px', background: '#fff', minHeight: '100%' }">
                              <RouterView />
                        </div>
                  </a-layout-content>
                  <a-layout-footer style="text-align: center">
                        Ant Design ©2018 Created by Ant UED
                  </a-layout-footer>
            </a-layout>
      </a-layout>
</template>

<script lang="ts" setup>
import {
      PieChartOutlined,
      DesktopOutlined,
      UserOutlined,
      TeamOutlined,
      FileOutlined,
} from '@ant-design/icons-vue';
import { ref, watchEffect } from 'vue';
import { useRouter } from "vue-router"

const router = useRouter()

const tr = router.currentRoute;
console.log(tr.value.name)
const collapsed = ref<boolean>(false);
const selectedKeys = ref<string[]>(['home']);

watchEffect(() => {
      selectedKeys.value = [router.currentRoute.value.name ? router.currentRoute.value.name.toString() : 'home']
})

</script>
<style scoped>
#components-layout-demo-side .logo {
      height: 32px;
      margin: 16px;
      background: rgba(255, 255, 255, 0.3);
}

.site-layout .site-layout-background {
      background: #fff;
}

[data-theme='dark'] .site-layout .site-layout-background {
      background: #141414;
}
</style>