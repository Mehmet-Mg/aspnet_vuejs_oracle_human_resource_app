<script setup lang="ts">
import DataGrid from '@/components/DataGrid.vue';
import type Employee from '@/models/Employee';
import { reactive, ref, watchEffect } from 'vue'
import dayjs, { Dayjs } from 'dayjs';

// const deletingEmployeeId = ref(null);
// const editingEmployee = ref<Employee>();
const searchQuery = ref('')
const showDeleteModal = ref(false);
// const showEditModal = ref(false);

const columns = [
    {
        name: 'Employeee Id',
        dataIndex: 'employeeId',
        key: 'employeeId',
    },
    {
        title: 'First Name',
        dataIndex: 'firstName',
        key: 'firstName',
    },
    {
        title: 'Last Name',
        dataIndex: 'lastName',
        key: 'lastName',
    },
    {
        title: 'E-Mail',
        key: 'email',
        dataIndex: 'email',
    },
    {
        title: 'Phone Number',
        key: 'phoneNumber',
        dataIndex: 'phoneNumber',
    },
    {
        title: 'Hire Date',
        key: 'hireDate',
        dataIndex: 'hireDate',
    },
    {
        title: 'Job Id',
        key: 'jobId',
        dataIndex: 'jobId',
    },
    {
        title: 'Salary',
        key: 'salary',
        dataIndex: 'salary',
    },
    {
        title: 'Commission',
        key: 'commissionPct',
        dataIndex: 'commissionPct',
    },
    {
        title: 'Manager Id',
        key: 'managerId',
        dataIndex: 'managerId',
    },
    {
        title: 'Department Id',
        key: 'departmentId',
        dataIndex: 'departmentId',
    },
    {
        title: 'Action',
        key: 'action',
    },
];

const gridData = ref<Employee[]>([]);
const open = ref<boolean>(false);

const showModal = () => {
    open.value = true;
};

const handleOk = (e: MouseEvent) => {
    console.log(e);
    open.value = false;
};

watchEffect(async () => {
    const url = `/api/employee`
    gridData.value = await (await fetch(url)).json()
})

interface FormState extends Partial<Employee> {
}

const formState = reactive<FormState>({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    jobId: '',
    salary: 0,
});
const onFinish = (values: any) => {
    console.log('Success:', values);
};

const onFinishFailed = (errorInfo: any) => {
    console.log('Failed:', errorInfo);
};

// function testDelete(entry: any) {
//     deletingEmployeeId.value = entry.employeeId;
//     showDeleteModal.value = true;
// }

// async function deleteEmployee() {
//     const url = `/api/employee/${deletingEmployeeId.value}`
//     const headers = {
//         'Content-Type': 'application/json',
//     };
//     const response = await fetch(url,
//         {
//             method: 'DELETE',
//             headers,
//         })
//     if (response.status === 200 && response.ok) {
//         gridData.value = gridData.value.filter(t => t.employeeId !== deletingEmployeeId.value)
//         deletingEmployeeId.value = null;
//         showDeleteModal.value = false;
//     }
// }

// function testEdit(entry: Employee) {
//     editingEmployee.value = { ...entry }
//     showEditModal.value = true;
// }

</script>

<template>
    <a-row>
        <a-col :span="4">
            <a-input placeholder="Search" />
        </a-col>
        <a-col :span="4" :offset="16">
            <a-button type="primary" @click="showModal" block>New Employee</a-button>
        </a-col>
    </a-row>
    <a-row :wrap="false">
        <a-col flex="auto">
            <DataGrid :data="gridData" :columns="columns" />
        </a-col>
    </a-row>
    <div>
        <a-modal v-model:open="open" title="New Employee" @ok="handleOk">
            <a-form :model="formState" name="basic" :label-col="{ span: 8 }" :wrapper-col="{ span: 16 }" autocomplete="off"
                @finish="onFinish" @finishFailed="onFinishFailed">
                <a-form-item label="First Name" name="firstName"
                    :rules="[{ required: true, message: 'Please input your firstName!' }]">
                    <a-input v-model:value="formState.firstName" />
                </a-form-item>

                <a-form-item label="Last Name" name="lastName"
                    :rules="[{ required: true, message: 'Please input your lastName!' }]">
                    <a-input v-model:value="formState.lastName" />
                </a-form-item>

                <a-form-item label="Email" name="email" :rules="[{ required: true, message: 'Please input your Email!' }]">
                    <a-input v-model:value="formState.email" />
                </a-form-item>

                <a-form-item label="Phone Number" name="phoneNumber"
                    :rules="[{ required: true, message: 'Please input your Phone Number!' }]">
                    <a-input v-model:value="formState.phoneNumber" />
                </a-form-item>

                <a-form-item label="Hire Date" name="hireDate"
                    :rules="[{ required: true, message: 'Please input your Hire Date!' }]">
                    <a-date-picker v-model:value="formState.hireDate" value-format="YYYY-MM-DD" />
                </a-form-item>

                <a-form-item label="jobId" name="Job Id"
                    :rules="[{ required: true, message: 'Please input your Hire Date!' }]">
                    <a-input v-model:value="formState.jobId" />
                </a-form-item>

                <a-form-item label="salary" name="Salary"
                    :rules="[{ required: true, message: 'Please input your Hire Date!' }]">
                    <a-input v-model:value="formState.salary" />
                </a-form-item>

                <a-form-item label="commissionPct" name="commissionPct"
                    :rules="[{ required: true, message: 'Please input your commissionPct!' }]">
                    <a-input v-model:value="formState.commissionPct" />
                </a-form-item>

                <a-form-item label="managerId" name="managerId"
                    :rules="[{ required: true, message: 'Please input your managerId!' }]">
                    <a-input v-model:value="formState.managerId" />
                </a-form-item>

                <a-form-item label="departmentId" name="departmentId"
                    :rules="[{ required: true, message: 'Please input your departmentId!' }]">
                    <a-input v-model:value="formState.departmentId" />
                </a-form-item>

                <a-form-item :wrapper-col="{ offset: 8, span: 16 }">
                    <a-button type="primary" html-type="submit">Submit</a-button>
                </a-form-item>
            </a-form>
        </a-modal>
    </div>
</template>