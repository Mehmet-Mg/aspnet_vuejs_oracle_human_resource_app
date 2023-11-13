<script setup lang="ts">
import DataGrid from '@/components/DataGrid.vue';
import { ref, watchEffect } from 'vue'

const searchQuery = ref('')

const columns = [
    {
        name: 'Department Id',
        dataIndex: 'departmentId',
        key: 'departmentId',
    },
    {
        title: 'Department Name',
        dataIndex: 'departmentName',
        key: 'departmentName',
    },
    {
        title: 'Manager Id',
        dataIndex: 'managerId',
        key: 'managerId',
    },
    {
        title: 'Location Id',
        key: 'locationId',
        dataIndex: 'locationId',
    },
    {
        title: 'Action',
        key: 'action',
    },
];

const gridData = ref([]);

watchEffect(async () => {
    const url = `/api/department`
    gridData.value = await (await fetch(url)).json()
})

</script>

<template>
	<form id="search">
		Search <input name="query" v-model="searchQuery">
	</form>
	<DataGrid :columns="columns" :data="gridData" />
</template>