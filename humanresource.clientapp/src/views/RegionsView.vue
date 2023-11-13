<script setup lang="ts">
import DataGrid from '@/components/DataGrid.vue';
import { ref, watchEffect } from 'vue'

const searchQuery = ref('')
const columns = [
    {
        name: 'Region Id',
        dataIndex: 'regionId',
        key: 'regionId',
    },
    {
        title: 'Region Name',
        dataIndex: 'regionName',
        key: 'regionName',
    },
    {
        title: 'Action',
        key: 'action',
    },
];

const gridData = ref([]);

watchEffect(async () => {
    const url = `/api/region`
    gridData.value = await (await fetch(url)).json()
})

</script>

<template>
	<form id="search">
		Search <input name="query" v-model="searchQuery">
	</form>
	<DataGrid 
		key="region_data_grid"
		:data="gridData"
		:columns="columns"
	/>
</template>