// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33505,y:32498,varname:node_4013,prsc:2|diff-4929-OUT;n:type:ShaderForge.SFN_Vector4Property,id:5301,x:32775,y:32334,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5301,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1,v2:0,v3:0,v4:1;n:type:ShaderForge.SFN_Slider,id:7489,x:32510,y:32756,ptovrint:False,ptlb:Rim Width,ptin:_RimWidth,varname:node_7489,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.964175,max:3;n:type:ShaderForge.SFN_ViewPosition,id:3847,x:32352,y:32888,varname:node_3847,prsc:2;n:type:ShaderForge.SFN_Subtract,id:3453,x:32523,y:32958,varname:node_3453,prsc:2|A-3847-XYZ,B-9247-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:9247,x:32352,y:33012,varname:node_9247,prsc:2;n:type:ShaderForge.SFN_Normalize,id:9654,x:32691,y:32958,varname:node_9654,prsc:2|IN-3453-OUT;n:type:ShaderForge.SFN_NormalVector,id:309,x:32691,y:33081,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:7855,x:32883,y:32958,varname:node_7855,prsc:2,dt:0|A-309-OUT,B-9654-OUT;n:type:ShaderForge.SFN_Max,id:3052,x:33053,y:32921,varname:node_3052,prsc:2|A-1367-OUT,B-7855-OUT;n:type:ShaderForge.SFN_Vector1,id:1367,x:32883,y:32891,varname:node_1367,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:7391,x:33213,y:32921,varname:node_7391,prsc:2|IN-3052-OUT;n:type:ShaderForge.SFN_Smoothstep,id:6823,x:33268,y:32634,varname:node_6823,prsc:2|A-9123-OUT,B-6462-OUT,V-7391-OUT;n:type:ShaderForge.SFN_OneMinus,id:9123,x:33337,y:32815,varname:node_9123,prsc:2|IN-7489-OUT;n:type:ShaderForge.SFN_Vector1,id:6462,x:33213,y:33063,varname:node_6462,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:4929,x:33155,y:32443,varname:node_4929,prsc:2|A-5301-XYZ,B-6823-OUT;proporder:5301-7489;pass:END;sub:END;*/

Shader "Shader Forge/Rimlight2" {
    Properties {
        _Color ("Color", Vector) = (1,0,0,1)
        _RimWidth ("Rim Width", Range(0.1, 3)) = 0.964175
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _RimWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (_Color.rgb+smoothstep( (1.0 - _RimWidth), 1.0, (1.0 - max(0.0,dot(i.normalDir,normalize((_WorldSpaceCameraPos-i.posWorld.rgb))))) ));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _RimWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (_Color.rgb+smoothstep( (1.0 - _RimWidth), 1.0, (1.0 - max(0.0,dot(i.normalDir,normalize((_WorldSpaceCameraPos-i.posWorld.rgb))))) ));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
